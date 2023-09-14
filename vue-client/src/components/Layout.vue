<template>
    <div>
      <Header v-if="showHeader" />
      <HomeView v-if="shouldRenderChild" :synth="synth" :recorder="recorder"/>
      <router-view />
    </div>
  </template>
  
  <script>
  import HomeView from '../views/HomeView.vue';
  import Header from './Header.vue';
  import * as Tone from "tone";
  
  let synth = new Tone.PolySynth().toDestination();
  let recorder = new Tone.Recorder();
  export default {
    components: {
    Header,
    HomeView
    },
    setup()
    {
        const showHeader=()=>
        {
          return !this.$route.meta.hideHeader;      
        }

        const toggleChildComponent=()=>
        {
          this.shouldRenderChild = !this.shouldRenderChild;
        }

        return {
          showHeader,
          toggleChildComponent
        }
    },
  };
  </script>