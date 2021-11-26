<template>
    <form class="form-inline" v-if="!this.logedIn">
      <MenuItem
      @click="loginClicked()"
      class="item"/>
    </form>
    <div v-else>
      <form class="form-inline">
        {{email}}
        <button class="btn btn-danger" @click="logout">Logout</button>
      </form>
    </div>
</template>
<script>
    import MenuItem from '../components/MenuItem.vue'

    export default {
  props:{
    cart: [],
    logedIn: Boolean,
    email: String
  },
components: {MenuItem },
methods: {
    logout(){
      localStorage.clear();
      this.logedIn = false;
    },
    
    loginClicked () {
      this.$router.push('/login')
    },
    
  }
    }
    
</script>
