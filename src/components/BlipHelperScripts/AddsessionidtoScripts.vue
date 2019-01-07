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
const blipScripts = require('blip.scripts')

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
    runScripts () {
      this.getBotDetails(this.selectedBot.shortName)
        .then(response => {
          this.botAccessKey = atob(response.data.accessKey)
          let authorizationKey = this.selectedBot.shortName + ':' + this.botAccessKey
          let encodedAuthKey = btoa(authorizationKey)
          this.getBotPublishedFlow(encodedAuthKey)
            .then(response => {
              let flow = response.data.resource
              const updatedFlow = blipScripts.addSessionId(flow)
              this.updatePublishedFlow({
                encodedAuthKey: encodedAuthKey,
                flow: updatedFlow
              })
            })
            .catch(error => this.notifyError(error))
        })
        .catch(error => this.notifyError(error))
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
