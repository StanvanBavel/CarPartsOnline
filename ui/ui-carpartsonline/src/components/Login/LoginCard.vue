<template>
  <div class="card">
    <div class="card-body">
      <form @submit.prevent="loginData">
        <FormTextInput v-on:emailData="setEmail"/>
        <PasswordInput v-on:passwordData="setPassword"/>
        <SubmitButton/>
      </form>
    </div>
  </div>
</template>

<script>
import FormTextInput from './FormTextInput.vue'
import PasswordInput from '@/components/Login/PasswordInput'
import CheckboxInput from '@/components/Login/CheckboxInput'
import SubmitButton from '@/components/Login/SubmitButton'

export default {
  name: 'LoginCard',
  data(){
    return{
      email: null,
      password: null
    }
  },
  components: {
    FormTextInput,
    PasswordInput,
    SubmitButton
  },
  methods:{
    setEmail(emailData){
      this.email = emailData
    },
    setPassword(passwordData){
      this.password = passwordData
    },
    loginData(){
      this.$emit("loginData", this.email, this.password);
    }
  }
}
</script>

<style scoped>
.card{
  width: 30%;
  margin-left: auto;
  margin-right: auto;
}
</style>
