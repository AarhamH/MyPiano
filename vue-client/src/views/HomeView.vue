<template>
  <div class="piano">
    <div class="white-key" @click="playNote('C4')">q</div>
    <div class="black-key" @click="playNote('Db4')">2</div>
    <div class="white-key" @click="playNote('D4')">w</div>
    <div class="black-key" @click="playNote('Eb4')">3</div>
    <div class="white-key" @click="playNote('E4')">e</div>
    <div class="white-key" @click="playNote('F4')">4</div>
    <div class="black-key" @click="playNote('Gb4')">r</div>
    <div class="white-key" @click="playNote('G4')">5</div>
    <div class="black-key" @click="playNote('Ab4')">t</div>
    <div class="white-key" @click="playNote('A4')">6</div>
    <div class="black-key" @click="playNote('Bb4')">y</div>
    <div class="white-key" @click="playNote('B4')">7</div>

    <div class="white-key" @click="playNote('C5')">u</div>
    <div class="black-key" @click="playNote('Db5')">8</div>
    <div class="white-key" @click="playNote('D5')">i</div>
    <div class="black-key" @click="playNote('Eb5')">9</div>
    <div class="white-key" @click="playNote('E5')">o</div>
    <div class="white-key" @click="playNote('F5')">0</div>
    <div class="black-key" @click="playNote('Gb5')">p</div>
    <div class="white-key" @click="playNote('G5')">-</div>
    <div class="black-key" @click="playNote('Ab5')">[</div>
    <div class="white-key" @click="playNote('A5')">=</div>
    <div class="black-key" @click="playNote('Bb5')">]</div>
    <div class="white-key" @click="playNote('B5')">Back</div>
  </div>
</template>

<script setup>
import * as Tone from "tone";

const playNote = (note) => {
  const synth = new Tone.Synth().toDestination();
  synth.triggerAttackRelease(note, "8n", Tone.now(), 3.5);
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

    case "u": playNote('C5'); break;
    case "8": playNote('Db5'); break;
    case "i": playNote('D5'); break;
    case "9": playNote('Eb5'); break;
    case "o": playNote('E5'); break;
    case "0": playNote('F5'); break;
    case "p": playNote('Gb5'); break;
    case "-": playNote('G5'); break;
    case "[": playNote('Ab5'); break;
    case "=": playNote('A5'); break;
    case "]": playNote('Bb5'); break;
    case "Backspace": playNote('B5'); break;

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