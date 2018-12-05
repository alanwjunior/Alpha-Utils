import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import guidService from './services/guid'

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
        id: guidService.newGuid(),
        method: 'get',
        uri: '/buckets/blip_portal:builder_published_flow'
      })
    },
    updatePublishedFlow ({ state, dispatch }, botFlow) {
      axios.defaults.headers.common = { 'Authorization': 'Key ' + botFlow.encodedAuthKey, 'Content-Type': 'application/json' }
      const userEmail = localStorage.getItem('userEmail')
      axios.post(state.blipSocketUrl + 'commands', {
        id: guidService.newGuid(),
        metadata: {
          'blip_portal.email': userEmail
        },
        method: 'set',
        resource: botFlow.flow,
        type: 'application/json',
        uri: '/buckets/blip_portal%3Abuilder_working_flow'
      })
        .then(response => {
          if (response.data.status === 'success') {
            this.$notify.success({
              title: 'Flow saved',
              message: 'Flow was saved successfully',
              showClose: false
            })
          } else {
            this.$notify.warning({
              title: 'Something went wrong',
              message: 'Please try again',
              showClose: false
            })
          }
        })
        .catch(error => dispatch('notifyError', error))
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
