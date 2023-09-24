<template>
  <Dashboard :word="word" :synth="synth" :recorder="recorder "/>
  <CreateRecordPopup v-if="doPopup">
    <h2>yes</h2>
    <button @click="doRecord">Create</button>
  </CreateRecordPopup>
  <Piano v-if="isHome" :synth="synth"/>
    {{ message }}
  <RecordedList/>
</template>

<script setup>
  import Dashboard from '../components/Dashboard.vue';
  import { doPopup } from '../components/Dashboard.vue';
  import Piano from '../components/Piano.vue'
  import { useRoute } from 'vue-router';
  import * as Tone from "tone";
  import RecordedList from '../components/RecordedList.vue';
  import CreateRecordPopup from '../components/CreateRecordPopup.vue';

  const synth = new Tone.PolySynth().toDestination();
  const recorder = new Tone.Recorder();

  const word = "yes";
  const bool = true;
  const route = useRoute()
  console.log(route.name)

  const isHome =()=>
  {
    if(route.name === 'home')
    {
      return true;
    }
    return false;
  }

  const doRecord = () => {
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
}


</script>

<style>
</style>