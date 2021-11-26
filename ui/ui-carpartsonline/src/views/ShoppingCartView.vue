<template>
<h1>Your cart</h1>
  <table class="table" style="border-top: 5px solid #d9322b; border-bottom: 5px solid #0f6fb7;
  background-color: white; ">
    <thead>
    <tr>
      <th scope="col"></th>
      <th scope="col">Name</th>
      <th scope="col">Amount</th>
      <th scope="col">Price</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="item in shoppingCart" :key="item.productID">
      <th><img class="img-cart" :src="(item.product.productImage)" alt="Product Image"></th>
      <td>{{item.product.productName}}</td>
      <td>{{item.amount}}</td>
      <td>{{item.product.productPrice}}</td>
    </tr>
    <tr>
      <td></td>
      <td></td>
      <td></td>
      <td><b>Total Price:</b> {{totalPriceCart}}</td>
    </tr>
    </tbody>
  </table>
  <button v-if="this.$root.logedIn" @click="confirmOrder" class="btn btn-success">Confirm Order</button>
</template>

<script>
export default {
  name: "ShoppingCart",
  data(){
    return{
      shoppingCart: [],
      totalPriceCart: 0
    }
  },
  props:{
    shoppingCartJson : ''
  },
  mounted() {
    this.convert();
  },
  methods:{
    convert(){
      this.shoppingCart = JSON.parse(this.shoppingCartJson);
      for (let i = 0; i < this.shoppingCart.length; i++) {
        this.totalPriceCart = (this.shoppingCart[i].product.productPrice * this.shoppingCart[i].amount) + this.totalPriceCart;
      }
    },
    confirmOrder(){
      this.$router.push(
          {
            name: "Order Overview",
            params: {
              shoppingCartJson: JSON.stringify(this.shoppingCart)
            }
          }
      )
    }
  }

}
</script>

<style scoped>
.table{
  width: 80%;
  margin-left: auto;
  margin-right: auto;
}
.img-cart{
  width: 100px;
}
</style>
