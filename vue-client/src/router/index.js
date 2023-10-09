import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import SignupView from '../views/SignupView.vue'
import LoginView from '../views/LoginView.vue'
import ErrorView from '../views/ErrorView.vue'
import stores from '../stores'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/signup',
      name: 'signup',
      component: SignupView,
      meta: { hideHeader: true }, // Add this meta field        
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
      meta: { hideHeader: true }, // Add this meta field        

    },
    {
      path: '/',
      name: 'home',
      component: HomeView,
      beforeEnter: (to, from, next) => {
        // Check if the user is authenticated using Vuex store state
        if (stores.state.authenticated) {
          // User is authenticated, allow access to the home route
          next();
        } else {
          // User is not authenticated, redirect to the login page
          next('/login');
        }
      },
    },
    {
      path: '/error',
      name: 'error',
      component: ErrorView
    },

  ]
});

export default router
