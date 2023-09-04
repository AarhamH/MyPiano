<template>
    <div class="control-board">
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
      </div>
    </div>
  </template>

<script>
import { ref, onMounted } from 'vue';
import * as Tone from 'tone';

const isChecked = ref(false);
export const isSustained = ref(false);
export default {
  props: {
    recorder: Object,
    synth: Object,
  },
  setup(props) {
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
      if (!isSustained.value) {
        console.log("sustain starting");
      } else {
        console.log("sustain stopping");
      }
      isSustained.value = !isSustained.value;
    };

    const useSustain = () => isSustained.value;

    // Start audio context when the component is mounted
    onMounted(() => {
      Tone.start();
    });

    return {
      isChecked,
      isSustained,
      handleCheckboxChange,
      handleSustain,
      useSustain,
    };
  },
};
export function useSustain(){return isSustained.value}
</script> 

  