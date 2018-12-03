<template>
  <div>
     <el-row class="util-section">
      <el-col :span="8">
        <el-card class="card-util">
          <div slot="header" class="clearfix card-util-title">
            <h3>Blip Helper Scripts</h3>
          </div>
          <div class="dashboard-cards">Accelerate your bot development process using scripts to create Trackings.</div>
          <el-button plain class="try-it-btn">Try it!</el-button>
        </el-card>
      </el-col>
      <el-col :span="8">
        <el-card class="card-util">
          <div slot="header" class="clearfix card-util-title">
            <h3>BLiP CLI</h3>
          </div>
          <div class="dashboard-cards">Implementing...</div>
          <el-button plain disabled class="try-it-btn">Try it!</el-button>
        </el-card>
      </el-col>
       <el-col :span="8">
         <el-card class="card-util">
            <div slot="header" class="clearfix card-util-title">
              <h3>BotStrapper</h3>
            </div>
            <div class="dashboard-cards">Create automatically your bot on three enviroments.</div>
            <el-button plain class="try-it-btn" @click="goToBotStrapper">Try it!</el-button>
         </el-card>
       </el-col>
     </el-row>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  created () {
    let token = localStorage.getItem('token')
    if (!token) {
      this.$router.push('/')
    }
  },
  mounted () {
    let token = localStorage.getItem('token')
    axios.defaults.headers.common = { 'Authorization': 'Token ' + token }
    axios.get('https://api.blip.ai/applications/mine')
      .then(response => {
        this.bots = response.data.map(r => r.name)
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
      bots: []
    }
  },
  methods: {
    goToBotStrapper () {
      this.$router.push('/botstrapper')
    }
  }
}
</script>

<style lang="scss" scoped>
.menu .el-tabs__header{
  background-color: #fff;
}

.card-util {
  width: 60%;
  margin: 0 auto;
  min-height: 30vh;
}

.util-section {
  padding: 5% 0%;
}

.dashboard-cards {
  padding: 10% 0%;
}

.try-it-btn {
  background-color: black;
  color: white;
  text-transform: uppercase;
  font-weight: 700;
  &:hover {
    border: 0px solid #FFF;
    background-color: black;
    color: white;
    opacity: 0.9;
  }
}
</style>
