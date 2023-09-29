<template>
  <header>
    <nav class="container">
      <div class="title">
        <h1>MyPiano</h1>
      </div>
      <ul class="nav-routes">
        Hello
        {{
          message
        }}!
      </ul>
    </nav>
  </header>
</template>

<script>
import { onMounted, ref } from "vue";
import { makeApiRequest } from "../utils/useFetch";
import { RouterLink } from "vue-router";

export const message = ref("You are not logged in");
export const theUserId = ref(-1);

export default {
  setup() {
    onMounted(async () => {
      let url = `https://localhost:7089/api/Auth/user`;
      const options = {
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);
      if (responseFlag) {
        message.value = responseData.username;
        theUserId.value = responseData.id;
      }
    });

    return { message, theUserId };
  },
};
</script>

<style>
header {
  background-color: #f1f1f1;
  nav {
    display: flex;
    align-items: center;
    padding: 25px 16px;

    .branding {
      display: flex;
      align-items: center;
      gap: 8px;
      img {
        max-width: 50px;
      }

      h1 {
        font-size: 24px;
      }
    }

    .nav-routes {
      display: flex;
      flex: 1;
      justify-content: flex-end;
      gap: 12px;
      list-style: none;

      a {
        text-decoration: none;
        color: inherit;
      }
    }
  }
}
</style>
