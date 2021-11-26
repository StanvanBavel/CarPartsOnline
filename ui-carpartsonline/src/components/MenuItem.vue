<template>
  <li class="nav-item active">
    <a class="nav-link" href="#" v-if="labelText"> {{ labelText }} </a>
    <a class="btn btn-success" href="#" v-else>Login</a>
  </li>

</template>

<script>

export default {
  props: {
    labelText: String
  }
}
</script>

<style scoped>

</style>
