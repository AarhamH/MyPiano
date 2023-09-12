<script setup>
import { RouterView } from 'vue-router'
import HomeView from './views/HomeView.vue';
import Layout from './components/Layout.vue';
</script>

<template>
  <Layout/>
</template>

<style lang="scss">
  @import url("https://fonts.googleapis.com/css2?family=Rubik:wght@300;400;500;700&display=swap");

  * {
    font-family: "Rubik", sans-serif;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  .container {
    max-width: 1100px;
    margin: 0 auto;
  }
</style>