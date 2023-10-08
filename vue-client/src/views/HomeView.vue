<template>
  <Dashboard :synth="synth" :recorder="recorder" />
  <CreateRecordPopup v-if="doPopup" :newRecordProp="newRecord">
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
import ErrorView from "./ErrorView.vue";
import router from '../router';

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

  },

  components: {
    Dashboard,
    Piano,
    CreateRecordPopup,
    RecordedList,
    ErrorView
},
};
</script>

<style></style>
