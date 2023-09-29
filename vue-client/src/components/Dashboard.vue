<template>
  <div class="control-board" v-if="isControlBoardVisible">
    <div class="button-container">
      <div class="checkbox-apple">
        <input
          class="yep"
          id="check-apple-record"
          type="checkbox"
          @change="handleCheckboxChange"
        />
        Record
        <label for="check-apple-record"></label>
      </div>
      <div class="checkbox-apple">
        <input
          class="yep"
          id="check-apple-sustain"
          type="checkbox"
          @change="handleSustain"
        />
        Sustain?
        <label for="check-apple-sustain"></label>
      </div>
      <div class="checkbox-apple">
        <input
          class="yep"
          id="check-apple-sustain"
          type="checkbox"
          @change="handleMetronome"
        />
        Metronome
        <label for="check-apple-sustain"></label>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import * as Tone from "tone";
import { useRoute } from "vue-router";

const isChecked = ref(false);
export let isSustained;
export const doPopup = ref(false);
const metronome = ref(false);

const route = useRoute();
export default {
  props: {
    recorder: Object,
    synth: Object,
  },
  setup(props) {
    isSustained = false;
    const handleCheckboxChange = () => {
      if (!isChecked.value) {
        props.recorder.start(); // Start recording
      } else {
        doPopup.value = true;
      }
      isChecked.value = !isChecked.value;
    };

    const handleSustain = () => {
      isSustained = !isSustained;
    };

    const isControlBoardVisible = () => {
      // Replace 'yourRouteName' with the actual name of the route where you want to display the control board
      return route.name === "home";
    };

    // Start audio context when the component is mounted
    onMounted(() => {
      Tone.start();
    });

    return {
      isChecked,
      doPopup,
      isSustained,
      handleCheckboxChange,
      handleSustain,
      isControlBoardVisible,
    };
  },
};
</script>
