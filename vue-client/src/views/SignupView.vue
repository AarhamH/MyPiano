<template>
    <div>
      <h2>Create New User</h2>
      <form @submit.prevent="createUser">
        <div>
          <label for="username">Username:</label>
          <input type="text" id="username" v-model="newUser.name" required />
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
  import axios from 'axios';
  import { useRouter } from 'vue-router';    
  import router from '../router';
  export default {
    data() {
      return {
        newUser: {
          name: '',
          email: '',
          password: '',
        },
      };
    },
    methods: {
      async createUser() {
        try {
          const response = await axios.post(`https://localhost:7089/api/Auth/register`, this.newUser);
          
          // Handle success (e.g., show a success message, clear the form)
          console.log('User created successfully:', response.data);
  
          // Optionally, you can redirect the user to a different page or update the UI as needed.
        } catch (error) {
          console.error('Error creating user:', error);
          // Handle errors here (e.g., show an error message)
        }
        await router.push('/login')

      },
    },
  };
  </script>