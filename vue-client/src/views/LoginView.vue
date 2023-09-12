<template>
    <div>
      <h2>Login</h2>
      <form @submit.prevent="loginUser">
        <div>
          <label for="email">Email:</label>
          <input type="email" id="email" v-model="logUser.email" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" id="password" v-model="logUser.password" required />
        </div>
        <div>
          <button type="submit">Create User</button>
        </div>
      </form>
    </div>
</template>

<script>
  import axios from 'axios';
  import router from '../router';
  export default {
    data() {
      return {
        logUser: {
          email: '',
          password: '',
        },
      };
    },
    methods: {
      async loginUser() {
        try {
          const response = await axios.post(`https://localhost:7089/api/Auth/login`, this.logUser);
          
          // Handle success (e.g., show a success message, clear the form)
          console.log('User logged in successfully:', response.data);

          // Optionally, you can redirect the user to a different page or update the UI as needed.
        } catch (error) {
          console.error('Error logging user:', error);
          // Handle errors here (e.g., show an error message)
        }
        await router.push('/')
      },
    },
  };
</script>

<style>

</style>