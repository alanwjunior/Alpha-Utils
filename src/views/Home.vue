<template>
  <div class="login">
    <el-row type="flex" justify="center">
      <el-col :span="8">
        <el-card class="box-card">
          <el-form>
            <h1 class="title">Login</h1>
            <el-row type="flex" justify="center">
              <el-col :span="16">
                 <el-form-item label="E-mail">
                    <el-input placeholder="E-mail" v-model="auth.username"></el-input>
                 </el-form-item>
              </el-col>
            </el-row>
            <el-row type="flex" justify="center">
              <el-col :span="16">
                <el-form-item label="Email">
                  <el-input placeholder="Password" type="password" v-model="auth.password"></el-input>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row type="flex" justify="center">
              <el-col :span="8">
                <el-button @click="login">Login</el-button>
              </el-col>
            </el-row>
          </el-form>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'home',
  components: {
  },
  data () {
    return {
      auth: {
        username: null,
        password: null
      }
    }
  },
  methods: {
    login () {
      let tokenUrl = 'https://api.blip.ai/accounts/' + this.auth.username + '/tokens'
      axios.post(tokenUrl, {}, { auth: this.auth })
        .then(response => {
          localStorage.setItem('token', response.data.token)
          axios.defaults.headers.common = { 'Authorization': 'Token ' + response.data.token }
          axios.get('https://api.blip.ai/accounts/me')
            .then(response => {
              localStorage.setItem('userName', response.data.fullName)
              localStorage.setItem('userId', response.dataid)
              this.$router.push('dashboard')
            })
            .catch(error => {
              this.$notify.error({
                title: 'Error',
                message: error.message,
                showClose: false
              })
            })
        })
        .catch(error => {
          this.$notify.error({
            title: 'Error',
            message: error.message,
            showClose: false
          })
        })
    }
  }
}
</script>

<style lang="scss" scoped>
.login {
  padding-top: 25vh;
  .title {
    padding: 5% 0%;
  }
}
</style>
