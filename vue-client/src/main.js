import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import stores from './stores' // Import your Vuex store here
import { makeApiRequest } from './utils/useFetch'
import { useRoute } from 'vue-router'

let url = `https://localhost:7089/api/Auth/user`;
const options = {
  headers: {
    "Content-Type": "application/json",
  },
  credentials: "include",
};

const { responseFlag, responseData } = await makeApiRequest(url, options);
if (responseFlag) {stores.commit("SET_AUTH",true)}
else {stores.commit("SET_AUTH",false)}

const app = createApp(App)

app.use(router)
app.use(stores)


app.mount('#app')
