<template>
  <h1>Order Overview</h1>
  <div class="flex-container">
    <div>
      <table class="table">
        <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Amount</th>
          <th scope="col">Price</th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="item in shoppingCart" :key="item.productID">
          <th scope="row"><img class="img-cart" :src="require('@/assets/' + item.product.productImage + '')" alt="Product Image"></th>
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
    </div>
    <div class="userdata">
      <table>
        <tr>
          <td>
            <b>Name: </b>
          </td>
          <td>
            {{firstName + " " + lastName}}
          </td>
        </tr>
        <tr>
          <td>
            <b>Address: </b>
          </td>
          <td>
            {{adress + housenumber + ", " + zipcode}}
          </td>
        </tr>
        <tr>
          <td>
            <b>City: </b>
          </td>
          <td>
            {{city}}
          </td>
        </tr>
      </table>
    </div>
  </div>
  <button class="btn btn-success" @click="placeOrder">Order</button>
</template>

<script>
import axios from "axios";

export default {
  name: "Order",
  data(){
    return{
      shoppingCart: [],
      totalPriceCart: 0,
      firstName : '',
      lastName: '',
      adress: '',
      housenumber: '',
      zipcode: '',
      city: ''
    }
  },
  props:{
    shoppingCartJson : ''
  },
  mounted() {
    this.convert();
    this.getUser();
  },
  methods: {
    convert() {
      this.shoppingCart = JSON.parse(this.shoppingCartJson);
      for (let i = 0; i < this.shoppingCart.length; i++) {
        this.totalPriceCart = (this.shoppingCart[i].product.productPrice * this.shoppingCart[i].amount) + this.totalPriceCart;
      }
    },
    async getUser(){
      axios.get('https://localhost:44334/Account/getUser', {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token') //the token is a variable which holds the token
        }
      })
        .then((response) => {
          this.firstName = response.data.firstName
          this.lastName = response.data.lastName
          // this.zipcode = response.data.zipcode
          this.adress = response.data.adress
          this.housenumber = response.data.housenumber
          // this.addition = response.data.addition
          this.city = response.data.city
        }, (error) => {
          console.log(error);
        });
    },
    async placeOrder(){

      const headers = {
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      }
      axios.post('https://localhost:44334/Order/order', this.shoppingCart, { headers })
          .then((response) => {
            console.log(response);
          });
    }
  }
}
</script>

<style scoped>

.flex-container {
  display: flex;
  flex-wrap: wrap;
}

.flex-container > div {
  width: 1000px;
  margin-top: 10px;
  margin-bottom: 10px;
  text-align: center;
  line-height: 75px;
  margin-left: auto;
  margin-right: auto;
}
.img-cart{
  width: 100px;
}
.userdata table tr td{
  font-size: 10px;
  height: 30px;
}
</style>
