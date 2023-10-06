import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import SignupView from '../views/SignupView.vue'
import LoginView from '../views/LoginView.vue'
import ErrorView from '../views/ErrorView.vue'

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
      path: '/',
      name: 'login',
      component: LoginView,
      meta: { hideHeader: true }, // Add this meta field        

    },
    {
      path: '/home',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/error',
      name: 'error',
      component: ErrorView
    },

  ]
});

export default router
