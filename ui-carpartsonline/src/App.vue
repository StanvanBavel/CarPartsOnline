<template>
  <div id="nav">
        <header>
          <div class="header">
                <img src="./assets/LogoMustang.png">
          </div>
        </header>

                <nav class="navbar navbar-expand-lg navbar-light">
              <div class="container-fluid">
                <a class="navbar-brand" href="#"><img class="logoSmall" src="./assets/logosmall.png"></a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                  <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                      <router-link class="nav-link"  to="/">Home |</router-link> 
                    </li>
                    <li class="nav-item">
                      <router-link class="nav-link"  to="/products">Products |</router-link> 
                    </li>
                    <li class="nav-item">
                      <router-link class="nav-link" to="/about">About |</router-link> 
                    </li>
                    <li class="nav-item">
                      <router-link class="nav-link" to="/product/create">Create Product</router-link>
                    </li>
                    <li class="nav-item dropdown">
                      <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Dropdown
                      </a>
                      <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="#">Action</a></li>
                        <li><a class="dropdown-item" href="#">Another action</a></li>
                        <li><hr class="dropdown-divider"></li>
                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                      </ul>
                    </li>
                    <li>
                      <LoginMenu
                      :logedIn="logedIn"
                      :email="email"
                      />
                    </li>
                    <li class="nav-item">
                      <router-link to="/register" class="nav-link active">Register</router-link>
                    </li>
                      
                    <li class="nav-item">
                      <ShoppingCart
                      :shoppingCart="Cart"
                      
                      />
                    </li>
                    <!-- <li class="nav-item">
                      <a class="nav-link disabled">Disabled</a>
                    </li> -->
                  </ul>
                  <form class="d-flex">
                  <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                  <button class="btn btn-outline-danger" type="submit">Search</button>
                </form>
                </div>
              </div>
            </nav>
  </div>
  <br>
  <!-- <ChatBot></ChatBot> -->
  <router-view v-on:setProductInCart="setShoppingCart" v-on:login="login"
  :logedIn="logedIn"
  />
</template>

<script>

import ShoppingCart from "../src/components/ShoppingCart.vue";
import LoginMenu from '../src/components/LoginMenu.vue';
import ChatBot from '@/components/ChatBot.vue'

export default {
data(){
    return{
      
      Cart: [],
      CartComputed: [],
      TotalPrice: Number,
      logedIn: false,
      email: ''
    }
  },
components: {ShoppingCart, LoginMenu, ChatBot},
methods:{
  
   login(data){
      localStorage.setItem('token',data.token);
      this.logedIn = true;
      this.email = data.email;
      this.$router.push("/");
    },
   setShoppingCart(product){
      //Elke keer als er een product toegevoegd wordt
      //Kijk of product al bestaat
      //zo niet, voeg normaal toe
      //zo wel, voeg amount toe
      //this.Cart.push(product)
      const productCart = {product, amount:1};

      if (this.Cart.length === 0){
        this.Cart.push(productCart);
        console.log("was empty, not anymore");
      }
      else{
        console.log("not the first product")
        for (let i = 0; i < this.Cart.length; i++) {
          if (product.productID === this.Cart[i].product.productID){
            console.log("same product");
            //update hier amount
            let objIndex = this.Cart.findIndex((obj => obj.product.productID == this.Cart[i].product.productID));
            console.log(objIndex);
            this.Cart[objIndex].amount++;
            console.log(this.Cart);
            return null;
          }
        }
        this.Cart.push(productCart);
      }
   }
}
}

</script>


<style >
#app{
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.logoSmall{
  height: 1em;
  width: 3em;
}

.navbar{
  border-top: 5px solid #d9322b;
  border-bottom: 5px solid #0f6fb7;
  background-color: white;
}

</style>
