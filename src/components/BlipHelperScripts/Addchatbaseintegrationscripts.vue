<template>
  <div class="regexifybot">
    <div slot="header" class="clearfix">
      <h1>Add Chatbase Integration Scripts</h1>
      <el-alert
        title="Add scripts required to integrate manually with chatnase. This scripts will be added on everyblock that has user interaction and or bot interaction and will send it to chatbase using post."
        type="info"
        show-icon>
      </el-alert>
      <el-alert
        title="It's necessary to register the bot variable: config.chatbaseURL, config.chatbasekey, config.version, config.chatbasetrack, config.platform"
        type="warning"
        show-icon>
      </el-alert>
    </div>
    <el-row>
      <bot-select @selectedBot="updateSelectedBot" :bots="bots"/>
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
    ...mapActions(['getBotDetails', 'getBotPublishedFlow', 'addchatbaseintegration', 'notifyError', 'updatePublishedFlow']),
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
              let updatedFlow = blipScripts.addChatbaseIntegration(flow)
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
