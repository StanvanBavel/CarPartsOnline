<template>
<h1>Your order has been placed!</h1>
  <h4> You will be redirected 👍</h4>
</template>

<script>
import router from "../router/index.js";
export default {
  name: "OrderSucceed",
  mounted() {
    this.$nextTick(function () {
      this.$root.emptyCart();
      setTimeout(function(){
        router.push("/");
      }, 2000);
    })
  }
}
</script>

<style scoped>

</style>
