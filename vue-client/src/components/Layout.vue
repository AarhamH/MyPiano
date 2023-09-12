<!-- Layout.vue -->
<template>
    <div>
      <Header v-if="hideHeader" />
      <RouterView/>
    </div>
  </template>
  
  <script>
  import Header from './Header.vue';
  import { RouterView } from 'vue-router'

  
  export default {
    components: {
      Header,
    },
    computed: {
      hideHeader() {
        // Conditionally show the header based on the current route
        return !['/login', '/signup'].includes(this.$route.path);
      },
    },
  };
  </script>