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
  import router from '../router';
  import { makeApiRequest } from '../utils/useFetch';

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
        let url = `https://localhost:7089/api/Auth/register`
        const options = {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.newUser),
          };

          const { responseFlag, responseData } = await makeApiRequest(url,options);
          if(responseFlag) { await router.push('/'); }
      },
    },
  };
</script>