import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    blipApiUrl: 'https://api.blip.ai/',
    alphaUtilsUrl: 'http://localhost:60813/api/',
    blipSocketUrl: 'https://msging.net/'
  },
  mutations: {
  },
  actions: {
    notifyError (error) {
      this.$notify.error({
        title: 'Error',
        message: error.message,
        showClose: false
      })
    },
    getBotDetails ({ state }, botShortName) {
      const token = localStorage.getItem('token')
      axios.defaults.headers.common = { 'Authorization': 'Token ' + token }
      return axios.get(state.blipApiUrl + 'applications/' + botShortName)
    },
    getBotPublishedFlow ({ state }, encodedAuthKey) {
      axios.defaults.headers.common = { 'Authorization': 'Key ' + encodedAuthKey, 'Content-Type': 'application/json' }
      return axios.post(state.blipSocketUrl + 'commands', {
        id: 'oskaoskaoksoakreaorkaokrae',
        method: 'get',
        uri: '/buckets/blip_portal:builder_published_flow'
      })
    },
    regexify ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/regexify', flow)
    },
    addtrackingandsession ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addtrackingandsession', flow)
    },
    addextras ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addextras', flow)
    },
    addstandardtracking ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addstandardtracking', flow)
    },
    addsessionid ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addsessionid', flow)
    },
    addlaststate ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addlaststate', flow)
    },
    addchatbaseintegration ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/addchatbaseintegration', flow)
    },
    clearbot ({ state }, flow) {
      return axios.post(state.alphaUtilsUrl + 'BlipHelperScripts/clearbot', flow)
    }
  }
})
