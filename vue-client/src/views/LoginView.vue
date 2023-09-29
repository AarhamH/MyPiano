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
  import router from '../router';
  import { makeApiRequest } from '../utils/useFetch';
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
        let url = `https://localhost:7089/api/Auth/login`;
        const options = {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify(this.logUser),
          };

        const { responseFlag, responseData } = await makeApiRequest(url,options);

        if(responseFlag) { await router.push('/home');}
        
      },
    },
  };
</script>

<style>

</style>