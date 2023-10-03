<template>
  <header>
    <nav class="container">
      <div class="title">
        <h1>MyPiano</h1>
      </div>
      <div class="action">
        <div class="profile" @click="menuToggle">
          <img src="../assets/icon.png" />
        </div>
        <div class="menu">
          <h3>Hello {{ message }}</h3>
          <ul>
            <li>
              <img src="../assets/logout.png" /><a @click="clearCookie()"
                >Logout</a
              >
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
import { onMounted, ref } from "vue";
import { makeApiRequest } from "../utils/useFetch";
import router from "../router";

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

  methods: {
    menuToggle() {
      const toggleMenu = document.querySelector(".menu");
      toggleMenu.classList.toggle("active");
    },

    async clearCookie() {
      let url = `https://localhost:7089/api/Auth/logout`;
      const options = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
      };

      const { responseFlag, responseData } = await makeApiRequest(url, options);

      if (responseFlag) {
        await router.push("/");
      }
    },
  },
};
</script>

<style>
header {
  margin-top: -10px;
  margin-left: -5px;
  margin-right: -5px;

  background-color: #171717;
  nav {
    display: flex;
    align-items: center;
    padding: 12px 8px;
    margin: 0;
    .title {
      color: aliceblue;
    }

    .nav-routes {
      display: flex;
      flex: 1;
      justify-content: flex-end;
      gap: 12px;
      list-style: none;
      color: aliceblue;
      margin-left: 20px;
    }
  }

  .action {
    position: fixed;
    top: 20px;
    right: 30px;
  }

  .action .profile {
    position: relative;
    width: 60px;
    height: 60px;
    border-radius: 50%;
    overflow: hidden;
    cursor: pointer;
  }

  .action .profile img {
    margin-left: 10px;
    margin-right: 10px;
    margin-top: 10px;

    width: 60%;
    height: 60%;
    object-fit: cover;
  }

  .action .menu {
    position: absolute;
    right: -7px;
    background: black;
    width: 200px;
    box-sizing: 0 5px 25px rgba(0, 0, 0, 0.1);
    border-radius: 15px;
    visibility: hidden;
    opacity: 0;
  }

  .action .menu.active {
    visibility: visible;
    opacity: 1;
  }

  .action .menu::before {
    content: "";
    position: absolute;
    top: -5px;
    right: 28px;
    width: 20px;
    height: 20px;
    background: black;
    transform: rotate(45deg);
  }

  .action .menu h3 {
    width: 100%;
    text-align: center;
    font-size: 18px;
    font-weight: 500;
    color: white;
    line-height: 1.5em;
  }

  .action .menu ul li {
    list-style: none;
    padding: 16px 0;
    border-top: 1px solid rgba(0, 0, 0, 0.05);
    display: flex;
    align-items: center;
  }

  .action .menu ul li img {
    max-width: 20px;
    margin-right: 10px;
    opacity: 0.5;
    transition: 0.5s;
  }

  .action .menu ul li:hover img {
    opacity: 1;
  }

  .action .menu ul li a {
    display: inline-block;
    text-decoration: none;
    color: #555;
    font-weight: 500;
    transition: 0.5s;
  }

  .action .menu ul li:hover a {
    cursor: pointer;
    color: #ff5d94;
  }
}
</style>
