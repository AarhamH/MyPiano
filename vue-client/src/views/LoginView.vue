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
          const response = await fetch(`https://localhost:7089/api/Auth/login`, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(this.logUser),
          });

          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }

          const responseData = await response.json();

          // Handle success (e.g., show a success message, clear the form)
          console.log('User logged in successfully:', responseData);

          // Optionally, you can redirect the user to a different page or update the UI as needed.
        } catch (error) {
          console.error('Error logging user:', error);
          // Handle errors here (e.g., show an error message)
        }
        await router.push('/');
      },
    },
  };
</script>

<style>

</style>