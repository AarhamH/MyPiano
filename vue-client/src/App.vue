<script setup>
import { useRoute } from 'vue-router';
import HomeView from './views/HomeView.vue';
import Header from './components/Header.vue';

const route = useRoute();

console.log(route.name)

const isHome = () => {
  if(route.name === 'home')
  {
    return true;
  }
  return false;
}
</script>

<template>
  <Header v-if="isHome()"/>
  <RouterView/>
</template>

<style lang="scss">
</style>