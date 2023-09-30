<template>
    <form class="form" @submit.prevent="createUser">
    <p id="heading">Signup</p>
    <div class="field">
      <input
        autocomplete="off"
        placeholder="Username"
        class="input-field"
        type="text"
        v-model="newUser.username" 
        required
      />
    </div>

    <div class="field">
      <input
        autocomplete="off"
        placeholder="Email"
        class="input-field"
        type="email"
        v-model="newUser.email"
        required
      />
    </div>

    <div class="field">
      <input
        placeholder="Password"
        class="input-field"
        type="password"
        v-model="newUser.password"
        required
      />
    </div>
    <div class="btn">
      <button class="button1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Register&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      </button>
      <button @click="goLogin" class="button2">Go back to login</button>
    </div>
    <div></div>
  </form>
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
      async goLogin() {
        await router.push("/")
      },
    },
  };
</script>

<style>
body {
  background-color: #1b1a1a;
}
.form {
  display: flex;
  flex-direction: column;
  gap: 10px;
  padding-left: 2em;
  padding-right: 2em;
  padding-bottom: 0.4em;
  background-color: #171717;
  border-radius: 25px;
  transition: 0.4s ease-in-out;
  margin: auto;
  width: 15%;
  margin-top: 10%;
}

.form:hover {
  transform: scale(1.05);
  border: 1px solid black;
}

#heading {
  text-align: center;
  margin: 2em;
  color: rgb(255, 255, 255);
  font-size: 1.2em;
}

.field {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.5em;
  border-radius: 25px;
  padding: 0.6em;
  border: none;
  outline: none;
  color: white;
  background-color: #171717;
  box-shadow: inset 2px 5px 10px rgb(5, 5, 5);
}

.input-icon {
  height: 1.3em;
  width: 1.3em;
  fill: white;
}

.input-field {
  background: none;
  border: none;
  outline: none;
  width: 100%;
  color: #d3d3d3;
}

.form .btn {
  display: flex;
  justify-content: center;
  flex-direction: row;
  margin-top: 2.5em;
  margin-bottom: 1rem;
}

.button1 {
  padding: 0.5em;
  padding-left: 1.1em;
  padding-right: 1.1em;
  border-radius: 5px;
  margin-right: 0.5em;
  border: none;
  outline: none;
  transition: 0.4s ease-in-out;
  background-color: #252525;
  color: white;
}

.button1:hover {
  background-color: black;
  color: white;
}

.button2 {
  padding: 0.5em;
  padding-left: 2.3em;
  padding-right: 2.3em;
  border-radius: 5px;
  border: none;
  outline: none;
  transition: 0.4s ease-in-out;
  background-color: #252525;
  color: white;
}

.button2:hover {
  background-color: black;
  color: white;
}

.button3 {
  margin-bottom: 3em;
  padding: 0.5em;
  border-radius: 5px;
  border: none;
  outline: none;
  transition: 0.4s ease-in-out;
  background-color: #252525;
  color: white;
}

.button3:hover {
  background-color: red;
  color: white;
}
</style>