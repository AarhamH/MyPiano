import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import SignupView from '../views/SignupView.vue'
import LoginView from '../views/LoginView.vue'
import Layout from '../components/Layout.vue'

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
      component: HomeView
    },

  ]
})

export default router
