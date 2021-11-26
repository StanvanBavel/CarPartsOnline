<template>
  <div class="form-group">
    <label>Your email</label>
    <input class="form-control" placeholder="Email" type="email" @input="emailData" v-model="email">
  </div>
</template>

<script>
export default {
  name: 'FormTextInput',
  data(){
    return{
      email: ''
    }
  },
  methods: {
    emailData(){
      this.$emit('emailData', this.email);
    }
  }
}
</script>

<style scoped>

</style>
