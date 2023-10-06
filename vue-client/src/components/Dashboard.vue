<template>
  <div class="control-board" v-if="isControlBoardVisible">
    <label class="switch">
      <input class="checkbox" type="checkbox" @change="handleCheckboxChange">
      <span class="slider"></span>
      <a>Record</a>
    </label>

    <label class="switch">
      <input class="checkbox" type="checkbox" @change="handleSustain">
      <span class="slider"></span>
      <a>Sustain</a>
    </label>

    <label class="switch">
      <audio
              ref="audioPlayer"
              id="audioPlayer"
              controls:display="'none'" loop 
              src="src\assets\metronome.mp3"         
            >
      </audio>
      <input class="checkbox" type="checkbox" @change="handleMetronome">
      <span class="slider"></span>
      <a>Metronome</a>
    </label>
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

    const handleMetronome = () => {
      if(!metronome.value)
      {
        const audioPlayer = document.getElementById("audioPlayer");
        audioPlayer.play();
      }
      else {
        audioPlayer.pause();
      }
      metronome.value = !metronome.value;
      console.log(metronome.value);

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
      metronome,
      handleCheckboxChange,
      handleSustain,
      handleMetronome,
      isControlBoardVisible,
    };
  },
};
</script>

<style>
/* Switch - Container */
.control-board {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 10px;
  margin-bottom: 40px;
}
.switch {
  --primary: #50F080;
  --secondary: #F05050;
  --dark: #505050;
  --light: #D0D0D0;
  background-color: var(--dark);
  position: relative;
  display: inline-block;
  border-radius: 1rem;
  cursor: pointer;
  width: 50px;
  height: 25px;
  margin-left: 50px;
}

/* Change the color of the <a> element inside the switch */
.switch a {
  display: flex;
  justify-content: center;
  align-items: center;
  color: white; /* Change the color to your desired color value */
}

/* Hide default HTML checkbox */
.checkbox {
  opacity: 0;
  margin-bottom: 15px;
}

/* The slider */
.slider {
  position: absolute;
  left: 0;
  top: 50%;
  width: 20%;
  height: 45%;
  transition: .4s;
  border-radius: 100%;
  transform: translateY(-50%);
  border: 4px solid var(--dark);
  background-color: var(--secondary);
}

.checkbox:checked + .slider {
  background-color: var(--primary);
  transform: translate(175%, -50%);
}
</style>