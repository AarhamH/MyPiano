<template>
  <div class="piano">
    <div class="checkbox-apple">
      <input class="yep" id="check-apple" type="checkbox" @change="handleCheckboxChange">
      <label for="check-apple"></label>
    </div>
    <div
      v-for="(key, index) in keyMappings"
      :key="index"
      :class="[key.isBlack ? 'black-key' : 'white-key']"
    >
      {{ key.key }}
    </div>
    </div>
</template>

<script setup>
import { defineProps } from 'vue'
import * as Tone from "tone";

const props = defineProps({
    synth:Tone.PolySynth
})

const synth = new Tone.PolySynth().toDestination(); // Use PolySynth to play multiple notes simultaneously
const recorder = new Tone.Recorder();
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
    props.synth.triggerRelease(note);
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
}
.white-key {
  border: 1px solid #000000;
  border-radius: 0px 0px 10px 10px;
  width: 100px;
  height: 400px;
  background-color: white;
  color: red;
  text-align: center;
}
.black-key {
  background-color: black;
  border-radius: 0px 0px 10px 10px;
  width: 60px;
  height: 250px;
  margin-left: -30px;
  margin-right: -30px;
  z-index: 1;
  color: red;
  text-align: center;
}
</style>