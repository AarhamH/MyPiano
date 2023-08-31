<template>
  <div class="piano">
    <div class="white-key" @click="playNote('C4')">A</div>
    <div class="black-key" @click="playNote('Db4')">W</div>
    <div class="white-key" @click="playNote('D4')">S</div>
    <div class="black-key" @click="playNote('Eb4')">E</div>
    <div class="white-key" @click="playNote('E4')">D</div>
    <div class="white-key" @click="playNote('F4')">F</div>
    <div class="black-key" @click="playNote('Gb4')">T</div>
    <div class="white-key" @click="playNote('G4')">G</div>
    <div class="black-key" @click="playNote('Ab4')">Y</div>
    <div class="white-key" @click="playNote('A4')">H</div>
    <div class="black-key" @click="playNote('Bb4')">U</div>
    <div class="white-key" @click="playNote('B4')">J</div>
  </div>
</template>

<script setup>
import * as Tone from "tone";

const playNote = (note) => {
  const synth = new Tone.Synth().toDestination();
  synth.triggerAttackRelease(note, "8n");
};

window.addEventListener("keydown", (event) => {
  switch (event.key) {
    case "q": playNote('C4'); break;
    case "2": playNote('Db4'); break;
    case "w": playNote('D4'); break;
    case "3": playNote('Eb4'); break;
    case "e": playNote('E4'); break;
    case "4": playNote('F4'); break;
    case "r": playNote('Gb4'); break;
    case "5": playNote('G4'); break;
    case "t": playNote('Ab4'); break;
    case "6": playNote('A4'); break;
    case "y": playNote('Bb4'); break;
    case "7": playNote('B4'); break;
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
  width: 100px;
  height: 400px;
  background-color: white;
  color: red;
  text-align: center;
}
.black-key {
  background-color: black;
  width: 60px;
  height: 250px;
  margin-left: -30px;
  margin-right: -30px;
  z-index: 1;
  color: red;
  text-align: center;
}
</style>