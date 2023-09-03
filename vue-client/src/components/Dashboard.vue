<template>
    <div class="control-board">
      <div class="button-container">
        <div class="checkbox-apple">
            <input class="yep" id="check-apple" type="checkbox" @change="handleCheckboxChange">
            <label for="check-apple"></label>
        </div>
      </div>
      <!-- Your content goes here -->
    </div>
  </template>

<script setup>
    import { defineProps } from 'vue'
    import * as Tone from 'tone'

    const props = defineProps({
        recorder:Tone.Recorder,
        synth:Tone.PolySynth,
        word:String
    })
    const handleCheckboxChange = () => {
        if (!isChecked) {
            console.log("recording starting")
            Tone.start(); // Ensure audio context is started
            props.synth.connect(props.recorder); // Connect the synth to the recorder
            props.recorder.start(); // Start recording
        } else {
            console.log("recording stopping")
            setTimeout(async () => {
            // the recorded audio is returned as a blob
            const recording = await props.recorder.stop();
            // download the recording by creating an anchor element and blob url
            const url = URL.createObjectURL(recording);
            const anchor = document.createElement("a");
            anchor.download = "recording.webm";
            anchor.href = url;
            anchor.click();
            }, 400);
        }
        isChecked = !isChecked;
    };
    let isChecked = false;

</script>
  