<template>
  <Dashboard :word="word" :synth="synth" :recorder="recorder "/>
  <CreateRecordPopup v-if="doPopup">
    <h2>Record the song?</h2>
    <input type="title" id="title" v-model="newRecord.title" required />
    <button @click="createRecord">Create</button>
  </CreateRecordPopup>
  <Piano v-if="isHome" :synth="synth"/>
  <RecordedList/>
</template>

<script>
  import Dashboard from '../components/Dashboard.vue';
  import Piano from '../components/Piano.vue'
  import { doPopup } from '../components/Dashboard.vue';
  import { useRoute } from 'vue-router';
  import { theUserId } from '../components/Header.vue';
  import * as Tone from "tone";
  import RecordedList from '../components/RecordedList.vue';
  import CreateRecordPopup from '../components/CreateRecordPopup.vue';

  export const volume = new Tone.Volume(0).toDestination();
  const synth = new Tone.PolySynth().connect(volume);
  const recorder = new Tone.Recorder();
  const route = useRoute()


  export default {
    data() {
      return {
        newRecord : {
          title: '',
          created: new Date(),
          filePath: 'whatever',
          userId: theUserId
        }
      }
    },
    setup() {
      const word = "yes";
      const bool = true;
      return {synth, recorder, word, bool, route, doPopup}
    },

    methods: {
      isHome() 
      {
        if(route.name === 'home')
        {
          this.turnOffPiano();
          return true;
        }
        return false;
      },
      async doRecord () {
      setTimeout(async () => { 
          // the recorded audio is returned as a blob
          const recording = await recorder.stop();
          // download the recording by creating an anchor element and blob URL
          const url = URL.createObjectURL(recording);
          const anchor = document.createElement("a");
          anchor.download = "recording.webm";
          anchor.href = url;
          anchor.click();
        }, 400);
      },

      async createRecord() {
        try {
          const response = await fetch(`https://localhost:7089/api/Audio`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.newRecord),
          });

          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
          window.location.reload()

         } catch (error) {
          console.error('Error creating user:', error);
          // Handle errors here (e.g., show an error message)
        }
      },
    },

    components: {
      Dashboard,
      Piano,
      CreateRecordPopup,
      RecordedList
    }
  };
</script>

<style>
</style>