<template>
  <Dashboard :word="word" :synth="synth" :recorder="recorder "/>
  <Piano v-if="isHome" :synth="synth"/>
    {{ message }}
  <RecordedList/>
</template>

<script setup>
  import Dashboard from '../components/Dashboard.vue';
  import Piano from '../components/Piano.vue'
  import { useRoute } from 'vue-router';
  import * as Tone from "tone";
  import RecordedList from '../components/RecordedList.vue';

  const synth = new Tone.PolySynth().toDestination();
  const recorder = new Tone.Recorder();

  const word = "yes";
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

</script>

<style>
</style>