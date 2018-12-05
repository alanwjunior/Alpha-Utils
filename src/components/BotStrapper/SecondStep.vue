<template>
  <el-col :span="20">
    <el-form>
      <el-form-item label="Enviroments:">
        <el-checkbox-group v-model="checkList">
          <el-checkbox label="Produção" disabled></el-checkbox>
          <el-checkbox label="Beta"></el-checkbox>
          <el-checkbox label="Homologação"></el-checkbox>
        </el-checkbox-group>
      </el-form-item>
      <el-form-item label="Chatbase Integration:">
        <el-switch
          v-model="hasChatbaseIntegration"
          active-color="#13ce66"
          inactive-color="#ff4949">
        </el-switch>
      </el-form-item>
      <el-form-item label="Chatbase Key:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase key" v-model="chatbaseKey" class="bot-name-input"></el-input>
      </el-form-item>
      <el-form-item label="Chatbase URL:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase URL" v-model="chatbaseURL" class="bot-name-input"></el-input>
      </el-form-item>
      <el-form-item label="Chatbase Platform:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase platform" v-model="chatbasePlatform" class="bot-name-input"></el-input>
      </el-form-item>
      <el-form-item label="Chatbase Platform:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase platform" v-model="chatbasePlatform" class="bot-name-input"></el-input>
      </el-form-item>
      <el-form-item label="Chatbase Track:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase track" v-model="chatbaseTrack" class="bot-name-input"></el-input>
      </el-form-item>
      <el-form-item label="Chatbot Version:" v-if="hasChatbaseIntegration">
        <el-input placeholder="Type the chatbase version" v-model="chatbotVersion" class="bot-name-input"></el-input>
      </el-form-item>
      <el-button class="btn-create-bot" @click="backFirstStep">Back</el-button>
      <el-button class="btn-create-bot" @click="createBots">Create</el-button>
    </el-form>
  </el-col>
</template>

<script>
export default {
  data () {
    return {
      checkList: ['Produção'],
      hasChatbaseIntegration: false,
      chatbaseKey: null,
      chatbaseURL: 'https://chatbase.com/api/message',
      chatbasePlatform: 'Blip chat',
      chatbaseTrack: 'https://chatbase.com/r?',
      chatbotVersion: '1.0'
    }
  },
  methods: {
    backFirstStep () {
      this.$emit('backFirstStep')
    }
  }
}
</script>

<style lang="scss" scoped>
.btn-create-bot {
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
</style>
