<template>
  <div class="regexifybot">
    <h1>Add Extras</h1>
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
    ...mapActions(['getBotDetails', 'getBotPublishedFlow', 'addextras', 'notifyError']),
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
              this.addextras({ Data: JSON.stringify(flow) })
                .then(response => {
                  console.log(response)
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
</style>
