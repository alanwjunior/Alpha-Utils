<template>
  <div class="botstrapper-container">
    <el-card class="botstrapper-card">
      <el-row>
        <el-col :span="4">
          <div style="height: 300px;">
            <el-steps direction="vertical" :active="stepNumber">
              <el-step title="Insert the bot name"></el-step>
              <el-step title="Result">Teste</el-step>
            </el-steps>
          </div>
        </el-col>
        <el-col :span="20">
          <div class="step-one" v-if="stepNumber === 1">
            <el-form label-position="top" label-width="100px">
                <el-form-item label="Bot Name:">
                  <el-input placeholder="Type the bot name" v-model="botName" class="bot-name-input">
                    <el-button slot="append" @click="createBot" class="">Create</el-button>
                  </el-input>
                </el-form-item>
            </el-form>
          </div>
        </el-col>
      </el-row>
    </el-card>
  </div>
</template>

<script>
export default {
  data () {
    return {
      stepNumber: 1,
      botName: ''
    }
  },
  methods: {
    createBot () {
      this.stepNumber++
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
