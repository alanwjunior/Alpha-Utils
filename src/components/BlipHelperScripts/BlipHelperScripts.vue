<template>
  <div class="blip-helper-scripts">
    <el-row :gutter="50">
      <el-col :span="6">
        <el-menu
          class="el-menu-vertical-demo"
          @open="handleOpen"
          @close="handleClose">
          <el-menu-item index="1" @click="navIdxSelected = 1">
              <span>Regexifybot</span>
          </el-menu-item>
          <el-menu-item index="2" @click="navIdxSelected = 2">
            <span>Add Tracking and Session</span>
          </el-menu-item>
          <el-menu-item index="3" @click="navIdxSelected = 3">
            <span>Add Extras</span>
          </el-menu-item>
          <el-menu-item index="4" @click="navIdxSelected = 4">
            <span>Add Standard Tracking Scripts</span>
          </el-menu-item>
          <el-menu-item index="5" @click="navIdxSelected = 5">
            <span>Add Session Id </span>
          </el-menu-item>
          <el-menu-item index="6" @click="navIdxSelected = 6">
            <span>Add Last State</span>
          </el-menu-item>
          <el-menu-item index="7" @click="navIdxSelected = 7">
            <span>Add Chatbase Integration</span>
          </el-menu-item>
          <el-menu-item index="8" @click="navIdxSelected = 8">
            <span>Clearbot</span>
          </el-menu-item>
        </el-menu>
      </el-col>
      <el-col :span="18">
        <el-card>
          <regexifybot v-if="navIdxSelected == 1" :bots="bots" />
          <addtrackingandsessionscripts v-if="navIdxSelected == 2" :bots="bots" />
          <addextras v-if="navIdxSelected == 3" :bots="bots" />
          <addstandardtrackingscripts v-if="navIdxSelected == 4" :bots="bots" />
          <addsessionidtoScripts v-if="navIdxSelected == 5" :bots="bots" />
          <addlaststatescript v-if="navIdxSelected == 6" :bots="bots" />
          <addchatbaseintegrationscripts v-if="navIdxSelected == 7" :bots="bots" />
          <clearbotscript v-if="navIdxSelected == 8" :bots="bots" />
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import Regexifybot from './Regexifybot.vue'
import Addtrackingandsessionscripts from './Addtrackingandsessionscripts.vue'
import Addextras from './Addextras.vue'
import Addstandardtrackingscripts from './Addstandardtrackingscripts.vue'
import AddsessionidtoScripts from './AddsessionidtoScripts.vue'
import Addlaststatescript from './Addlaststatescript.vue'
import Addchatbaseintegrationscripts from './Addchatbaseintegrationscripts.vue'
import Clearbotscript from './Clearbotscript.vue'
import { mapActions } from 'vuex'
export default {
  components: {
    Regexifybot: Regexifybot,
    Addtrackingandsessionscripts: Addtrackingandsessionscripts,
    Addextras: Addextras,
    Addstandardtrackingscripts: Addstandardtrackingscripts,
    AddsessionidtoScripts: AddsessionidtoScripts,
    Addlaststatescript: Addlaststatescript,
    Addchatbaseintegrationscripts: Addchatbaseintegrationscripts,
    Clearbotscript: Clearbotscript
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
      navIdxSelected: null,
      bots: null
    }
  },
  methods: {
    ...mapActions(['listBots']),
    handleOpen (key, keyPath) {
      console.log(key, keyPath)
    },
    handleClose (key, keyPath) {
      console.log(key, keyPath)
    }
  }
}
</script>

<style>
.blip-helper-scripts {
  width: 80%;
  margin: 0 auto;
  padding-top: 5%;
}
</style>
