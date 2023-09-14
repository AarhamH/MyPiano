<template>
    <div class="control-board" v-if="isControlBoardVisible">
      <div class="button-container">
        <div class="checkbox-apple">
          <input class="yep" id="check-apple-record" type="checkbox" @change="handleCheckboxChange">
          Record
          <label for="check-apple-record"></label>
        </div>
        <div class="checkbox-apple">
          <input class="yep" id="check-apple-sustain" type="checkbox" @change="handleSustain">
          Sustain?
          <label for="check-apple-sustain"></label>
        </div>
        <div class="checkbox-apple">
          <input class="yep" id="check-apple-sustain" type="checkbox" @change="handleMetronome">
          Metronome
          <label for="check-apple-sustain"></label>
        </div>
      </div>
    </div>
  </template>

<script>
import { ref, onMounted } from 'vue';
import * as Tone from 'tone';
import { useRoute } from 'vue-router';

const isChecked = ref(false);
export let isSustained;
const metronome  = ref(false);

const route = useRoute();

const metronomeSound = new Tone.PolySynth().toDestination();
export default {
  props: {
    recorder: Object,
    synth: Object,
  },
  setup(props) {
    isSustained = false;
    const handleCheckboxChange = () => {
      if (!isChecked.value) {
        console.log("recording starting");
        Tone.start(); // Ensure audio context is started
        props.synth.connect(props.recorder); // Connect the synth to the recorder
        props.recorder.start(); // Start recording
      } else {
        console.log("recording stopping");
        setTimeout(async () => {
          // the recorded audio is returned as a blob
          const recording = await props.recorder.stop();
          // download the recording by creating an anchor element and blob URL
          const url = URL.createObjectURL(recording);
          const anchor = document.createElement("a");
          anchor.download = "recording.webm";
          anchor.href = url;
          anchor.click();
        }, 400);
      }
      isChecked.value = !isChecked.value;
    };

    const handleSustain = () => {
      if (!isSustained) {
        console.log("sustain starting");
      } else {
        console.log("sustain stopping");
      }
      isSustained = !isSustained;
    };

    const isControlBoardVisible = () => {
     // Replace 'yourRouteName' with the actual name of the route where you want to display the control board
      return route.name === 'home';
};

    // Start audio context when the component is mounted
    onMounted(() => {
      Tone.start();
    });

    return {
      isChecked,
      isSustained,
      handleCheckboxChange,
      handleSustain,
      isControlBoardVisible
    };
  },
};
</script> 

  