<template>
  <div class="regexifybot">
    <h1>Add Session Id</h1>
    <el-alert
      title="Add scripts required to track the session of the user. This scripts will be added on everyblock that has user interaction and will update the session ID if the last interacion is grater than time configured in config.sessionTime."
      type="info"
      show-icon>
    </el-alert>
    <el-alert
      title="It's necessary to register the bot variable: config.sessionTime"
      type="warning"
      show-icon>
    </el-alert>
    <el-row>
      <bot-select @selectedBot="updateSelectedBot" :bots="bots" />
    </el-row>
    <el-row>
      <el-button @click="runScripts">Go</el-button>
    </el-row>
  </div>
</template>

<script>
import BotSelect from './../commons/BotSelect.vue'
import { mapActions } from 'vuex'
import blipApi from 'blip-version-control-integration'
const blipScripts = require('blip.scripts')
const blipService = blipApi.newBlipService(localStorage.getItem('token'))

export default {
  components: {
    BotSelect: BotSelect
  },
  props: {
    bots: {
      type: Array,
      required: true
    }
  },
  data () {
    return {
      selectedBot: null,
      labelPosition: 'top',
      botAccessKey: null
    }
  },
  methods: {
    ...mapActions(['getBotDetails', 'getBotPublishedFlow', 'addsessionid', 'notifyError', 'updatePublishedFlow']),
    updateSelectedBot (bot) {
      this.selectedBot = bot
    },
    async runScripts () {
       try {
        let flow = await blipService.getPublishedFlowAsync(this.selectedBot.shortName)
        const updatedFlow = blipScripts.addSessionId(flow)
        let updateStatus = await blipService.updateSavedFlowAsync(updatedFlow, this.selectedBot.shortName)
        if (updateStatus.status === 'success') {
          Notification.success({
            title: 'Flow saved',
            message: 'Flow was saved successfully',
            showClose: false
          })
        }
      } catch (error) {
        Notification.error({
          title: 'Error',
          message: error.message,
          showClose: false
        })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.bot-select {
  padding-top: 5%;
}

.regexifybot h1 {
  padding-bottom: 1%;
}
</style>
