<template>
    <div class="popup">
      <div class="popup-inner">
        <slot />
        <button class="create-record" @click="handleCreateRecord">Create</button>
        <button class="cancel">Cancel</button>
      </div>
    </div>
  </template>
  
  <script>
import { onMounted } from 'vue';
import { volume } from '../views/HomeView.vue';
import { synth } from '../views/HomeView.vue';
import { recorder } from '../views/HomeView.vue';

  export let recording;
  export default {
    setup () {
        onMounted(async () => {
            volume.volume.value = -Infinity;
            synth.disconnect(recorder);
            recording = await recorder.stop();

        })
    }
  };
  </script>

<style lang="scss" scoped>
    .popup {
        position: fixed;
        top: 0;
        bottom: 0;
        left: 0;
        right: 0;
        z-index: 99;
        background-color: rgba(0,0,0,0.2);
        display: flex;
        align-items: center;
        justify-content: center;


        .popup-inner {
            background-color: white;
            padding: 32px;

        }
    }
</style>