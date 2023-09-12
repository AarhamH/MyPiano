<template>
    <div>
      <h2>Login</h2>
      <form @submit.prevent="">
        <div>
          <label for="email">Email:</label>
          <input type="email" id="email" placeholder="newUser.email" required />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" id="password" placeholder="newUser.password" required />
        </div>
        <div>
          <button type="submit">Create User</button>
        </div>
      </form>
    </div>
</template>

<script>
    export default{
        name:"Login"
    }
</script>

<style>

</style>