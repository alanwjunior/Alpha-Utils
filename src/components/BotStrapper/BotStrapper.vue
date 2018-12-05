<template>
  <div class="botstrapper-container">
    <el-card class="botstrapper-card">
      <el-row>
        <el-col :span="4">
          <div style="height: 300px;">
            <el-steps direction="vertical" :active="stepNumber">
              <el-step title="Insert the bot name"></el-step>
              <el-step title="Configuration"></el-step>
              <!-- <el-step title="Resources"></el-step> -->
              <el-step title="Result"></el-step>
            </el-steps>
          </div>
        </el-col>
        <first-step  v-if="stepNumber === 1" @goToSecondStep="stepNumber = 2" />
        <second-step v-if="stepNumber === 2" @goToResult="stepNumber = 3" @backFirstStep="stepNumber = 1"/>
      </el-row>
    </el-card>
  </div>
</template>

<script>
import FirstStep from './FirstStep.vue'
import SecondStep from './SecondStep.vue'

export default {
  components: {
    FirstStep: FirstStep,
    SecondStep: SecondStep
  },
  data () {
    return {
      stepNumber: 1,
      botName: ''
    }
  },
  methods: {
    goToConfigurations () {
      this.stepNumber++
    },
    createBot () {
      // const token = localStorage.getItem('token')
      // axios.post('https://api.blip.ai/applications')
      //   .then()
    }
  }
}
</script>

<style lang="scss" scoped>
.botstrapper-container {
  padding-top: 5%;
  width: 80%;
  margin: 0 auto;
}

.step-one {
  text-align: left;
}
.bot-name-input {
  width: 60%;
}

.step-one .create-bot-btn {
  background-color: black;
  color: white;
  font-weight: 700;
  &:hover {
    background-color: black;
    color: white;
    opacity: 0.9;
  }
}
</style>
