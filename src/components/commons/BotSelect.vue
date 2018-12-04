<template>
  <el-form class="bot-select" label-width="120px" :label-position="labelPosition" >
    <el-form-item prop="botName" label="Selecione o bot:" v-if="bots">
      <el-select v-model="selectedBot" placeholder="Select" @change="selectBot">
        <el-option
          v-for="item in bots"
          :key="item.id"
          :label="item.shortName"
          :value="item.shortName">
        </el-option>
      </el-select>
    </el-form-item>
  </el-form>
</template>

<script>
import axios from 'axios'
export default {
  mounted () {
    const token = localStorage.getItem('token')
    axios.defaults.headers.common = { 'Authorization': 'Token ' + token }
    axios.get('https://api.blip.ai/applications/mine')
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
      bots: null,
      selectedBot: null,
      labelPosition: 'top'
    }
  },
  methods: {
    selectBot () {
      const bot = this.bots.find(b => b.shortName === this.selectedBot)
      this.$emit('selectedBot', bot)
    }
  }
}
</script>

<style lang="scss" scoped>
.bot-select {
  padding-top: 5%;
}
</style>
