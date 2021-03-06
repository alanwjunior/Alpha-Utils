import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Dashboard from './components/Dashboard.vue'
import BotStrapper from './components/BotStrapper/BotStrapper'
import BlipHelperScripts from './components/BlipHelperScripts/BlipHelperScripts.vue'
import BlipCLI from './components/BlipCLI/BlipCLI.vue'
import BotTranslator from './components/BotTranslator/BotTranslator'
import BotAutomaticDeploy from './components/BlipAutomaticDeploy/BlipAutomaticDeploy'

Vue.use(Router)

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard
    },
    {
      path: '/botstrapper',
      name: 'botstrapper',
      component: BotStrapper
    },
    {
      path: '/bliphelperscripts',
      name: 'bliphelperscripts',
      component: BlipHelperScripts
    },
    {
      path: '/blipcli',
      name: 'blipcli',
      component: BlipCLI
    },
    {
      path: '/bottranslator',
      name: 'bottranslator',
      component: BotTranslator
    },
    {
      path: '/BotAutomaticDeploy',
      name: 'BotAutomaticDeploy',
      component: BotAutomaticDeploy
    }
  ]
})

// router.beforeEach((to, from, next) => {
//   const token = localStorage.token
//   if (token && to.path === '/') {
//     next('/dashboard')
//   } else if (!token) {
//     next('/')
//   } else {
//     next()
//   }
// })

export default router
