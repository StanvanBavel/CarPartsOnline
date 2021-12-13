<template>
  <H1>My Orders</H1>
  <table class="table">
    <thead>
    <tr>
      <th scope="col">#OrderNumber</th>
      <th scope="col">Date</th>
      <th scope="col">Items</th>
      <th scope="col">Action</th>
    </tr>
    </thead>
    <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>@mdo</td>
    </tr>
    </tbody>
  </table>
</template>

<script>

import axios from "axios";

export default {
  name: "UserOrder",
  mounted:
    this.$nextTick(function () {
      axios.get('https://localhost:44334/order', {
        headers: {
          'Authorization': `Bearer ${this.getItem('token')}`
        }
      })
    })
}
</script>

<style scoped>

</style>
