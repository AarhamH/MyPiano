<template>
  <Dashboard :word="word" :synth="synth" :recorder="recorder"/>
  <Piano :synth="synth"/>
</template>

<script setup>
  import Dashboard from '../components/Dashboard.vue';
  import Piano from '../components/Piano.vue'
  import * as Tone from "tone";

  const synth = new Tone.PolySynth().toDestination(); // Use PolySynth to play multiple notes simultaneously
  const recorder = new Tone.Recorder();

  const word = "hello"
</script>

<style>
</style>