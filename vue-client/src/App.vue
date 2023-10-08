<script setup>
import { useRoute } from "vue-router";
import Header from "./components/Header.vue";
import ErrorView from "./views/ErrorView.vue";
const route = useRoute();

console.log(route.name);

const isHome = () => {
  if (route.name === "home") {
    return true;
  }
  return false;
};
</script>

<template>
  <Header v-if="isHome()" />
  <RouterView />
</template>

<style lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Quicksand:wght@400&display=swap');

* {
  font-family: "Quicksand"
}
</style>
