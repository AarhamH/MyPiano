<script setup>
import Layout from './components/Layout.vue';
import { useRoute } from 'vue-router';
import HomeView from './views/HomeView.vue';
import Header from './components/Header.vue';
</script>

<template>
  <Header/>
  <RouterView/>
</template>

<style lang="scss">
</style>