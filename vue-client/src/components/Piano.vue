<template>
  <div class="piano">
    <div
      v-for="(key, index) in keyMappings"
      :key="index"
      :class="[key.isBlack ? 'black-key' : 'white-key']"
    >
      <span :class="[key.isBlack ? 'black-text' : 'white-text']">
        {{ key.key }}
      </span>
    </div>
    </div>
</template>

<script setup>
import { defineProps, ref } from 'vue'
import * as Tone from "tone";
import { isSustained } from './Dashboard.vue';

const props = defineProps({
    synth:Tone.PolySynth
})

const pressedKeys = new Set();
const keyMappings = [
  { key: "q", note: "C4", isBlack: false },
  { key: "2", note: "Db4", isBlack: true },
  { key: "w", note: "D4", isBlack: false },
  { key: "3", note: "Eb4", isBlack: true },
  { key: "e", note: "E4", isBlack: false },
  { key: "4", note: "F4", isBlack: false },
  { key: "r", note: "Gb4", isBlack: true },
  { key: "5", note: "G4", isBlack: false },
  { key: "t", note: "Ab4", isBlack: true },
  { key: "6", note: "A4", isBlack: false },
  { key: "y", note: "Bb4", isBlack: true },
  { key: "7", note: "B4", isBlack: false },
  { key: "u", note: "C5", isBlack: false },
  { key: "8", note: "Db5", isBlack: true },
  { key: "i", note: "D5", isBlack: false },
  { key: "9", note: "Eb5", isBlack: true },
  { key: "o", note: "E5", isBlack: false },
  { key: "0", note: "F5", isBlack: false },
  { key: "p", note: "Gb5", isBlack: true },
  { key: "-", note: "G5", isBlack: false },
  { key: "[", note: "Ab5", isBlack: true },
  { key: "=", note: "A5", isBlack: false },
  { key: "]", note: "Bb5", isBlack: true },
  { key: "Backspace", note: "B5", isBlack: false }
];

const playNote = (note) => {
  if (!pressedKeys.has(note)) {
    props.synth.triggerAttack(note);
    pressedKeys.add(note);
  }
};

const releaseNote = (note) => {
  if (pressedKeys.has(note)) {
    if(isSustained)
    {
        setTimeout(async () => {
        props.synth.triggerRelease(note);
        },400)       
    }
    else{
        setTimeout(async () => {
        props.synth.triggerRelease(note);
        },0)      
    }
    console.log(isSustained.value)

    pressedKeys.delete(note);
  }

};

window.addEventListener("keydown", (event) => {
  const keyMapping = keyMappings.find((mapping) => mapping.key === event.key);
  if (keyMapping) {
    playNote(keyMapping.note);
    console.log(keyMapping.note)
  }
});

window.addEventListener("keyup", (event) => {
  const keyMapping = keyMappings.find((mapping) => mapping.key === event.key);
  if (keyMapping) {
    releaseNote(keyMapping.note);
  }
});
</script>

<style>
.piano {
  display: flex;
  justify-content: center;
  padding-top: 20px;
  margin-left: 280px ;
  margin-right: 280px;

  padding-bottom: 20px;

  background-color:#171717 ;
}
.white-key {
  border-radius: 0px 0px 10px 10px;
  width: 100px;
  height: 400px;
  background-color: ivory;
  border-radius:0 0 5px 5px;
  box-shadow:-1px 0 0 rgba(255,255,255,0.8) inset,0 0 5px #ccc inset,0 0 3px rgba(0,0,0,0.7);
  text-align: center;
}
.black-key {
  box-shadow:-1px -1px 2px rgba(255,255,255,0.2) inset,0 -5px 2px 3px rgba(0,0,0,0.6) inset,0 2px 4px rgba(0,0,0,0.5);  
  border-radius: 0px 0px 10px 10px;
  background:linear-gradient(45deg,#222 0%,#555 100%);
  width: 60px;
  height: 250px;
  margin-left: -30px;
  margin-right: -30px;
  z-index: 1;
  text-align: center;
}

.white-text {
  margin: auto;
  width: 50%;
  padding-top: 350px;
  display: table;
  vertical-align: bottom;
}

.black-text {
  padding-top: 500px;
  top: 5px; /* Adjust the top position as needed */
  left: 0;
  right: 0;
  color: white; /* Set the color for the top text */
}
</style>