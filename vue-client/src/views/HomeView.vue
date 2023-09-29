<template>
  <Dashboard :synth="synth" :recorder="recorder" />
  <CreateRecordPopup v-if="doPopup">
    <h2>Record the song?</h2>
    <input type="title" id="title" v-model="newRecord.title" required />
    <button @click="uploadAudioFile">Create</button>
  </CreateRecordPopup>
  <Piano v-if="isHome" :synth="synth" />
  <RecordedList />
</template>

<script>
import Dashboard from "../components/Dashboard.vue";
import Piano from "../components/Piano.vue";
import { doPopup } from "../components/Dashboard.vue";
import { useRoute } from "vue-router";
import { theUserId } from "../components/Header.vue";
import { recording } from "../components/CreateRecordPopup.vue";
import * as Tone from "tone";
import RecordedList from "../components/RecordedList.vue";
import CreateRecordPopup from "../components/CreateRecordPopup.vue";
import { makeApiRequest } from "../utils/useFetch";

export const volume = new Tone.Volume(0).toDestination();
export const synth = new Tone.PolySynth().connect(volume);
export const recorder = new Tone.Recorder();
const route = useRoute();
synth.connect(recorder);

export default {
  data() {
    return {
      newRecord: {
        title: "",
        created: new Date(),
        filePath: "",
        userId: theUserId,
      },
    };
  },
  setup() {
    return { synth, recorder, route, doPopup };
  },

  methods: {
    isHome() {
      return route.name === "home";
    },
    async uploadAudioFile() {
      let url = `https://localhost:7089/api/Audio/upload`;
      const formData = new FormData();
      let recordTitle = this.newRecord.title;
      formData.append("file", recording, recordTitle + ".webm"); // Replace "audioFileBlob" with your Blob

      const options = {
        method: "POST",
        body: formData,
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);
      if (responseFlag) {
        this.createRecord(responseData.filePath);
      }
    },

    async createRecord(path) {
      let url = `https://localhost:7089/api/Audio`;
      this.newRecord.filePath = path;
      let jsonBody = JSON.stringify(this.newRecord);

      let options = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: jsonBody,
      };
      const { responseFlag } = await makeApiRequest(url, options); // Use await here

      if (responseFlag) {
        window.location.reload();
      }
    },
  },

  components: {
    Dashboard,
    Piano,
    CreateRecordPopup,
    RecordedList,
  },
};
</script>

<style></style>
