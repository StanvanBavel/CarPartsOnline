<template>
  <div class="form-group">
    <input class="form-control" placeholder="******" type="password" @input="passwordData" v-model="password">
    <a class="float-right" href="#">Forgot </a>
    <label>your password?</label>
  </div>
</template>

<script>
export default {
  name: 'PasswordInput',
  data(){
    return{
      password: ''
    }
  },
  methods: {
    passwordData(){
      this.$emit('passwordData', this.password);
    }
  }
}
</script>

<style scoped>
a{
  color: dimgray;
  text-decoration: grey;
}
a:hover{
  color: red;
}
</style>
