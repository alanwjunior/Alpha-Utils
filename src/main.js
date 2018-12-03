import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'

Vue.config.productionTip = false

axios.interceptors.request.use(function (config) {
  const token = localStorage.token
  if (token || config.url.indexOf('tokens') !== -1) {
    return config
  } else {
    router.push('/')
    return Promise.reject(new Error('Please login first!'))
  }
}, function (error) {
  return Promise.reject(error)
})

Vue.use(ElementUI)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
