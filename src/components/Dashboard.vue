<template>
  <div>
     <el-row class="util-section">
      <el-col :span="8">
        <el-card class="card-util">
          <div slot="header" class="clearfix card-util-title">
            <h3>Blip Helper Scripts</h3>
          </div>
          <div class="dashboard-cards">Accelerate your bot development process using scripts to create Trackings.</div>
          <el-button plain class="try-it-btn" @click="goToBlipHelperScripts">Try it!</el-button>
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
export default {
  created () {
    let token = localStorage.getItem('token')
    if (!token) {
      this.$router.push('/')
    }
  },
  data () {
    return {
    }
  },
  methods: {
    goToBotStrapper () {
      this.$router.push('/botstrapper')
    },
    goToBlipHelperScripts () {
      this.$router.push('/bliphelperscripts')
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
  min-height: 7vw;
}

.try-it-btn {
  background-color: #8e8f92;
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
