<template>
  <form @submit.prevent="register">
    <h1 class="h3 mb-3 fw-normal">Please Register</h1>
    <input v-model="name" type="text" class="form-control" placeholder="Name" required>
    <input v-model="email" type="email" class="form-control" placeholder="Email" required>
    <input v-model="password" type="password" class="form-control" placeholder="Password" required>
    <button class="w-100 btn btn-lg btn-primary" type="submit">Submit</button>
  </form>
</template>

<script lang="js">
import axios from "axios";

export default {
  name: "Register",
  data(){
    return{
        name: "",
        email: "",
        password: ""
    }
  },
  methods:{
    register(){
      axios.post('https://localhost:44334/Account/register',{
        "name": this.name,
        "email": this.email,
        "password": this.password
      })
        .then((response) => {
          localStorage.setItem("token",response.data)
          console.log(response.data)
          this.$router.push("/login")
        })
    }
  }
}
</script>

<style scoped>

</style>
