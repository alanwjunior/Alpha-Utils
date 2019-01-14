<template>
    <div class="blip-automatic-deploy">
        <el-card>
            <el-row>
                <h1>Blip Automatic Deploy</h1>
            </el-row>
            <el-row>
                <el-steps :active="active" finish-status="success">
                    <el-step title="Integration">
                    </el-step>
                    <el-step title="Authentication">2</el-step>
                    <el-step title="Deploy">3</el-step>
                </el-steps>
                <div v-if="active == 0" class="step-content">
                  <h3>Select the Version Control Tool to save your flow:</h3>
                  <el-select v-model="selectedVersionControlTool" placeholder="Select the tool">
                    <el-option
                      v-for="item in versionControlTools"
                      :key="item.value"
                      :label="item.label"
                      :value="item.value">
                    </el-option>
                  </el-select>
                  <el-button @click="nextStep">Next Step</el-button>
                </div>
                <div v-if="active == 1" class="step-content">
                  <h3>Please, fiil your credentials to authenticate on {{ this.selectedVersionControlTool }}:</h3>
                  <el-row type="flex" justify="center" class="authenticate-inputs">
                    <el-col :span="4">
                      <el-input placeholder="Username" v-model="auth.userCredential.username"></el-input>
                    </el-col>
                  </el-row>
                  <el-row type="flex" justify="center" class="authenticate-inputs">
                    <el-col :span="4">
                      <el-input placeholder="Password" type="password" v-model="auth.userCredential.password"></el-input>
                    </el-col>
                  </el-row>
                  <el-row type="flex" justify="center" class="authenticate-inputs">
                    <el-col :span="4">
                      <el-input placeholder="Repository" v-model="auth.repositoryName"></el-input>
                    </el-col>
                  </el-row>
                  <el-row type="flex" justify="center" class="authenticate-inputs">
                    <el-col :span="4">
                      <el-input placeholder="Branch" v-model="auth.branchName"></el-input>
                    </el-col>
                  </el-row>
                  <el-row type="flex" justify="center" class="authenticate-inputs">
                    <el-col :span="4">
                      <el-input placeholder="Commit message" v-model="auth.newCommitMessage"></el-input>
                    </el-col>
                  </el-row>
                  <el-button @click="nextStep">Next Step</el-button>
                </div>
                <div v-if="active == 2" class="step-content">
                  <h3>Automatic Deploy</h3>
                  <bot-select :bots="bots" :selectLabel="'Source Bot:'" @selectedBot="selectedSourceBot" />
                  <bot-select :bots="bots" :selectLabel="'Destiny Bot:'" @selectedBot="selectedDestinyBot" />
                  <el-button @click="deploy">Deploy</el-button>
                </div>
            </el-row>
        </el-card>
    </div>
</template>

<script>
import { mapActions } from 'vuex'
import BotSelect from './../commons/BotSelect'
import blipControlVersion from 'blip-version-control-integration'
const blipIntegrationService = blipControlVersion.newBlipService(localStorage.getItem('token'))

export default {
  components: {
    BotSelect: BotSelect
  },
  mounted () {
    this.listBots()
      .then(response => {
        this.bots = response.data
      })
      .catch(error => {
        this.$notify.error({
          title: 'Error',
          message: error.message,
          showClose: false
        })
      })
  },
  data () {
    return {
      bots: [],
      active: 0,
      selectedVersionControlTool: 'GitHub',
      versionControlTools: [{ value: 'GitHub', label: 'GitHub' }],
      auth: {
        userCredential: {
          username: '',
          password: ''
        },
        repositoryName: '',
        branchName: '',
        newCommitMessage: ''
      },
      sourceBotShortName: '',
      destinyBotShortName: ''
    }
  },
  methods: {
    ...mapActions(['listBots']),
    nextStep () {
      if (this.active === 0) {
        this.active++
      } else if (this.active === 1) {
        if (this.isAuthValid()) {
          this.active++
        }
      }
    },
    isAuthValid () {
      return this.auth.userCredential.username && this.auth.userCredential.password && this.auth.repositoryName &&
        this.auth.branchName && this.auth.newCommitMessage
    },
    async deploy () {
      await blipIntegrationService.deployUsingGithubAsync(this.sourceBotShortName, this.destinyBotShortName, this.auth)
      console.log('finished')
    },
    selectedSourceBot (bot) {
      this.sourceBotShortName = bot.shortName
    },
    selectedDestinyBot (bot) {
      this.destinyBotShortName = bot.shortName
    }
  }
}
</script>

<style>
.blip-automatic-deploy {
  width: 80%;
  margin: 0 auto;
  padding-top: 5%;
}

.step-content {
  padding: 5% 0%;
}

.step-content h3 {
  padding-bottom: 1%;
}

.authenticate-inputs {
  padding-bottom: 1%;
}
</style>
