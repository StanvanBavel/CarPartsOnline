<template>
  <h1>Login</h1>
  <Card v-on:loginData="login"/>
  <h1 v-if="err">Your password and email do not match</h1>
</template>

<script>
import Card from '@/components/Login/LoginCard'
import axios from "axios";
export default {
  name: 'Login',
  components: {
    Card
  },
  data(){
    return{
      err: null
    }
  },
  methods:{
    async login(email, password){
      axios({
        method: 'post',
        url: 'https://localhost:44344/Account/login',
        data: {
          email: email,
          password: password
        }
      })
      .then((response) => {
        if (response.data.token == null)
        {
          this.err = true;
        }
        else{
          this.$emit('login', response.data)
        }
      }, (error) => {
        console.log(error);
      });
    }

  }
}
</script>

<style scoped>
h1{
  margin-left: auto;
  margin-right: auto;
  text-align: center;
}
</style>
