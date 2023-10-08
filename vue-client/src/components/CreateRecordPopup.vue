<template>
  <div class="popup">
    <div class="popup-inner">
      <h2 class="header">Record the song?</h2>
      <div class="field">
        <input class="field-input" type="title" id="title" v-model="newRecordProp.title" required />
      </div>
      <div class="button-container">
        <button class="field-button" @click="uploadAudioFile">Create</button>
        <button class="field-button" @click="canclePopup">Cancle</button>
      </div>

    </div>
  </div>
</template>

<script>
import { onMounted } from "vue";
import { volume } from "../views/HomeView.vue";
import { synth } from "../views/HomeView.vue";
import { recorder } from "../views/HomeView.vue";
import { makeApiRequest } from "../utils/useFetch";
import { doPopup } from "../components/Dashboard.vue";

export let recording;
export default {
  props: {
    newRecordProp: Object,
  },

  setup() {
    onMounted(async () => {
      volume.volume.value = -Infinity;
      synth.disconnect(recorder);
      recording = await recorder.stop();
    });
  },

  methods: {
    async uploadAudioFile() {
      let url = `https://localhost:7089/api/Audio/upload`;
      const formData = new FormData();
      let recordTitle = this.newRecordProp.title;
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

    canclePopup() {
      doPopup.value = false;
      volume.volume.value = 0;
      synth.connect(recorder);
      return;
    },

    async createRecord(path) {
      let url = `https://localhost:7089/api/Audio`;
      this.newRecordProp.filePath = path;
      let jsonBody = JSON.stringify(this.newRecordProp);

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
};
</script>

<style lang="scss" scoped>
.popup {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: 99;
  background-color: rgba(0, 0, 0, 0.7);
  display: flex;
  align-items: center;
  justify-content: center;

  .popup-inner {
    background-color: #171717;
    border-radius: 20px;
    padding: 32px;

    .field {
      display: flex;
      align-items: center;
      justify-content: center;
      gap: 0.5em;
      border-radius: 25px;
      padding: 0.6em;
      border: none;
      outline: none;
      color: white;
      background-color: #171717;
      margin: 10px;

      .field-input {
        background: none;
        border: none;
        outline: none;
        width: 100%;
        color: #d3d3d3;      
      }
    }

    .button-container {
      display: flex;
      justify-content: center;
      align-items: center;

      .field-button {
        padding: 0.5em;
        padding-left: 1.1em;
        padding-right: 1.1em;
        border-radius: 5px;
        margin-right: 0.5em;
        border: none;
        outline: none;
        transition: 0.4s ease-in-out;
        background-color: #252525;
        color: white;
        cursor: pointer;
      }

      .field-button:hover {
        background-color: black;
        color: #F05050;
       
      }
    }
    .header {
      text-align: center;
      color: white;
    }
  }
}
</style>
