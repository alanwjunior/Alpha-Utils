<template>
  <el-form label-width="120px" :label-position="labelPosition" >
    <el-form-item prop="botName" :label="selectLabel" v-if="bots">
      <el-select v-model="selectedBot" placeholder="Select" @change="selectBot">
        <el-option
          v-for="item in bots"
          :key="item.id"
          :label="item.name"
          :value="item.shortName">
        </el-option>
      </el-select>
    </el-form-item>
  </el-form>
</template>

<script>
export default {
  props: {
    bots: {
      type: Array,
      required: true
    },
    selectLabel: {
      default: 'Selecione o bot'
    }
  },
  data () {
    return {
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
