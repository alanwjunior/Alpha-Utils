<template>
  <div id="app">
    <div id="nav">
    </div>
    <app-header v-if="!isLoginPage"/>
    <router-view/>
  </div>
</template>

<script>
import AppHeader from './components/commons/Header.vue'
export default {
  components: {
    AppHeader: AppHeader
  },
  computed: {
    isLoginPage () {
      return this.$route.path === '/'
    }
  }
}
</script>

<style lang="scss">
* {
  margin: 0px;
  padding: 0px;
}

h1, h2, h3, h4, h5, h6, p {
  font-family: 'Roboto Condensed', sans-serif;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  background-color: #81259D;
  min-height: 100vh;
}
</style>
