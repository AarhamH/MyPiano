<template>
  <div class="piano">
    <div class="white-key" @click="playC4">A</div>
    <div class="black-key" @click="playDb4">W</div>
    <div class="white-key" @click="playD4">S</div>
    <div class="black-key" @click="playEb4">E</div>
    <div class="white-key" @click="playE4">D</div>
    <div class="white-key" @click="playF4">F</div>
    <div class="black-key" @click="playGb4">T</div>
    <div class="white-key" @click="playG4">G</div>
    <div class="black-key" @click="playAb4">Y</div>
    <div class="white-key" @click="playA4">H</div>
    <div class="black-key" @click="playBb4">U</div>
    <div class="white-key" @click="playB4">J</div>
    <div class="white-key" @click="playC5">K</div>
  </div>
</template>

<script setup>
import * as Tone from "tone";

const playNote = (note) => {
  const synth = new Tone.Synth().toDestination();
  synth.triggerAttackRelease(note, "8n");
};

const playC4 = () => playNote("C4");
const playDb4 = () => playNote("Db4");
const playD4 = () => playNote("D4");
const playEb4 = () => playNote("Eb4");
const playE4 = () => playNote("E4");
const playF4 = () => playNote("F4");
const playGb4 = () => playNote("Gb4");
const playG4 = () => playNote("G4");
const playAb4 = () => playNote("Ab4");
const playA4 = () => playNote("A4");
const playBb4 = () => playNote("Bb4");
const playB4 = () => playNote("B4");
const playC5 = () => playNote("C5");

window.addEventListener("keydown", (event) => {
  switch (event.key) {
    case "a": playC4(); break;
    case "w": playDb4(); break;
    case "s": playD4(); break;
    case "e": playEb4(); break;
    case "d": playE4(); break;
    case "f": playF4(); break;
    case "t": playGb4(); break;
    case "g": playG4(); break;
    case "y": playAb4(); break;
    case "h": playA4(); break;
    case "u": playBb4(); break;
    case "j": playB4(); break;
    case "k": playC5(); break;
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