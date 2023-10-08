import { createStore } from 'vuex';

export default createStore({
  state: {
    authenticated: false,
  },  
  mutations: {
    SET_AUTH(state, auth) {
      state.authenticated = auth;
    },
  },
  actions: {
    login({ commit }) {
      // Logic for authenticating the user
      commit('SET_AUTH', true); // Set authenticated to true upon successful login
    },
    logout({ commit }) {
      // Logic for logging the user out
      commit('SET_AUTH', false); // Set authenticated to false upon logout
    },
  },
});