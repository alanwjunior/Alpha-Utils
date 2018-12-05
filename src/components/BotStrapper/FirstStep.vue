<template>
  <el-col :span="20">
    <div class="step-one">
      <el-form label-position="top" label-width="100px" class="botstrapper-form">
          <el-form-item label="Bot Name:">
            <el-input placeholder="Type the bot name" v-model="botName" class="bot-name-input"></el-input>
            <el-button class="btn-next" @click="goToSecondStep">Next</el-button>
          </el-form-item>
      </el-form>
    </div>
  </el-col>
</template>

<script>
export default {
  data () {
    return {
      botName: null
    }
  },
  methods: {
    goToSecondStep () {
      if (this.botName) {
        this.$emit('goToSecondStep', this.botName)
      } else {
        this.$notify.warning({
          title: 'Warning',
          message: 'Please, type the bot name!',
          showClose: false
        })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.btn-next {
  margin-top: 5%;
  background-color: #8e8f92;
  color: white;
  font-weight: 700;
  &:hover {
    border: 0px solid #FFF;
    background-color: black;
    color: white;
    opacity: 0.9;
  }
}

.botstrapper-form {
  width: 80%;
  margin: 0 auto;
}
</style>
