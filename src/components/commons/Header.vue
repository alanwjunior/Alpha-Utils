<template>
  <div class="menu">
    <el-row type="flex" justify="end">
      <el-col :span="4" class="logotipo">
        <h1>Alpha Utils</h1>
      </el-col>
      <el-col :span="12" :offset="8">
        <el-row>
          <el-col :span="4" class="menu-item">
            <span>Blip Helper Scrips</span>
          </el-col>
          <el-col :span="4" class="menu-item">
            <span>Blip CLI</span>
          </el-col>
          <el-col :span="4" class="menu-item">
            <span>BotStrapper</span>
          </el-col>
          <el-col :span="4" :offset="4" class="menu-item">
            <el-dropdown @command="handleDropdown">
              <span class="el-dropdown-link">
                {{this.userName}}<i class="el-icon-arrow-down el-icon--right"></i>
              </span>
              <el-dropdown-menu slot="dropdown">
                <el-dropdown-item>Bots</el-dropdown-item>
                <el-dropdown-item command="logout" divided>Logout</el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </el-col>
        </el-row>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  mounted () {
    this.userName = localStorage.getItem('userName')
  },
  data () {
    return {
      userName: null
    }
  },
  methods: {
    handleDropdown (command) {
      if (command === 'logout') {
        localStorage.clear()
        this.$router.push('/')
      } else {
        console.log('command')
      }
    }
  }
}
</script>

<style scoped>
.menu {
  background-color: #fff;
}

.logotipo {
  padding: 1% 0%;
}

.menu-item {
  padding: 3% 0%;
}

.menu-item span {
  font-family: 'Roboto Condensed', sans-serif;
  font-weight: 700;
}
</style>
