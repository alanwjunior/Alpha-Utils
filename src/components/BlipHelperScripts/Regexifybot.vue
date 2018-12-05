<template>
  <div class="regexifybot">
    <h1>Regexify</h1>
    <el-alert
      title="Turns all the conditions to from a specific bot that check the user input into regex expressions. Can also be used to turn a sigle expression on a regex for blip."
      type="info"
      show-icon>
    </el-alert>
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
    ...mapActions(['getBotDetails', 'getBotPublishedFlow', 'regexify', 'notifyError']),
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
              this.regexify({ Data: JSON.stringify(flow) })
                .then(response => {
                  console.log(response.data)
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
