<template>
  <div class="regexifybot">
    <h1>Add Tracking and Session</h1>
    <el-alert
      title="Add standard Trackings and SessionId to all block that have the [] marking in the name. If you add the flag -all at the end will append to all blocks in the buider."
      type="info"
      show-icon>
    </el-alert>
    <el-row>
      <bot-select @selectedBot="updateSelectedBot"/>
    </el-row>
    <el-row>
      <el-button @click="runScripts">Go</el-button>
    </el-row>
  </div>
</template>

<script>
import BotSelect from './../commons/BotSelect.vue'
import { mapActions } from 'vuex'
export default {
  components: {
    BotSelect: BotSelect
  },
  data () {
    return {
      selectedBot: null,
      labelPosition: 'top',
      botAccessKey: null
    }
  },
  methods: {
    ...mapActions(['getBotDetails', 'getBotPublishedFlow', 'addtrackingandsession', 'notifyError']),
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
              this.addtrackingandsession({ Data: JSON.stringify(flow) })
                .then(response => {
                  const updatedFlow = response.data
                  this.updatePublishedFlow({
                    encodedAuthKey: encodedAuthKey,
                    flow: updatedFlow
                  })
                })
                .catch(error => this.notifyError(error))
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
