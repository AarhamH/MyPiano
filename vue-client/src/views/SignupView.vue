<template>
    <div>
      <h2>Create New User</h2>
      <form @submit.prevent="createUser">
        <div>
          <label for="username">Username:</label>
          <input type="text" id="username" v-model="newUser.username" required />
        </div>
        <div>
          <label for="email">Email:</label>
          <input type="email" id="email" v-model="newUser.email" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" id="password" v-model="newUser.password" required />
        </div>
        <div>
          <button type="submit">Create User</button>
        </div>
      </form>
    </div>
  </template>
  
  <script>
  import { useRouter } from 'vue-router';    
  import router from '../router';

  export default {
    data() {
      return {
        newUser: {
          username: '',
          email: '',
          password: '',
        },
      };
    },
    methods: {
      async createUser() {
        try {
          const response = await fetch(`https://localhost:7089/api/Auth/register`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.newUser),
          });

          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }

         } catch (error) {
          console.error('Error creating user:', error);
          // Handle errors here (e.g., show an error message)
        }
        await router.push('/login');
      },
    },
  };
</script>