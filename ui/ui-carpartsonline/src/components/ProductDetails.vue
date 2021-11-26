<template>
 


 <div class="container">
 <section class="mb-5">

  <div class="row">
    <div class="col-md-6 mb-4 mb-md-0">

      <div id="mdb-lightbox-ui"></div>

      <div class="mdb-lightbox">

        <div class="row product-gallery mx-1">

          <div class="col-12 mb-0">
            <figure class="view overlay rounded z-depth-1 main-img">
              
                <img :src="(product[0].productImage)"
                  class="img-fluid z-depth-1">
             
            </figure>
            <!-- <figure class="view overlay rounded z-depth-1" style="visibility: hidden;">
              <a href="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/12a.jpg"
                data-size="710x823">
                <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/12a.jpg"
                  class="img-fluid z-depth-1">
              </a>
            </figure>
            <figure class="view overlay rounded z-depth-1" style="visibility: hidden;">
              <a href="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/13a.jpg"
                data-size="710x823">
                <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/13a.jpg"
                  class="img-fluid z-depth-1">
              </a>
            </figure>
            <figure class="view overlay rounded z-depth-1" style="visibility: hidden;">
              <a href="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/14a.jpg"
                data-size="710x823">
                <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/14a.jpg"
                  class="img-fluid z-depth-1">
              </a>
            </figure> -->
          </div>
          <!-- <div class="col-12">
            <div class="row">
              <div class="col-3">
                <div class="view overlay rounded z-depth-1 gallery-item">
                  <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/12a.jpg"
                    class="img-fluid">
                  <div class="mask rgba-white-slight"></div>
                </div>
              </div>
              <div class="col-3">
                <div class="view overlay rounded z-depth-1 gallery-item">
                  <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/13a.jpg"
                    class="img-fluid">
                  <div class="mask rgba-white-slight"></div>
                </div>
              </div>
              <div class="col-3">
                <div class="view overlay rounded z-depth-1 gallery-item">
                  <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/14a.jpg"
                    class="img-fluid">
                  <div class="mask rgba-white-slight"></div>
                </div>
              </div>
              <div class="col-3">
                <div class="view overlay rounded z-depth-1 gallery-item">
                  <img src="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/15a.jpg"
                    class="img-fluid">
                  <div class="mask rgba-white-slight"></div>
                </div>
              </div>
            </div>
          </div> -->
        </div>

      </div>

    </div>
    <div class="col-md-6">

      <h5>{{this.product[0].productName}}</h5>
      <p class="mb-2 text-muted text-uppercase small">CarParts</p>
      
      <p><span class="mr-1"><strong>${{this.product[0].productPrice}}</strong></span></p>
      <p class="pt-1">{{this.product[0].productDescription}}</p>
      <div class="table-responsive">
        <table class="table table-sm table-borderless mb-0">
          <tbody>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Model</strong></th>
              <td>Shirt 5407X</td>
            </tr>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Color</strong></th>
              <td>Black</td>
            </tr>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Delivery</strong></th>
              <td>USA, Europe</td>
            </tr>
          </tbody>
        </table>
      </div>
      <hr>
      <!-- <div class="table-responsive mb-2">
        <table class="table table-sm table-borderless">
          <tbody>
            <tr>
              <td class="pl-0 pb-0 w-25">Quantity</td>
              <td class="pb-0">Select size</td>
            </tr>
            <tr>
              <td class="pl-0">
                <div class="def-number-input number-input safari_only mb-0">
                  
                  <input class="quantity" min="0" name="quantity" value="1" type="number">
                  
                </div>
              </td>
              
            </tr>
          </tbody>
        </table>
      </div> -->
      <!-- <button type="button" class="btn btn-primary btn-md mr-1 mb-2">Buy now</button> -->
      <button type="button" class="btn btn-light" style="border-top: 5px solid #d9322b; border-bottom: 5px solid #0f6fb7;
  background-color: white; " @click.self="toCart()">
        <i class="material-icons" >add_shopping_cart</i> Add to cart</button>
    </div>
  </div>

</section>   

 </div>
</template>
<script>

import axios from "axios";
import Product from "../classes/Product";
export default {
  name: "ProductDetails",
  
  data(){
    return{
      id: Number,
      productNAME: "",
      product: [],
    };
  },

  // created(){
  //   this.id = this.$route.params.id;
  // },
  // methods:{
  //   refreshData(){
  //     axios.get('https://localhost:44334/Product/'+ this.id)
  //         .then((response) => {
  //           this.product = response.data;
  //           console.log(this.product[0])
  //           this.id = response.data.productID
  //         })
  //   },
  created(){
    this.id = this.$route.params.id;
    this.refreshData();
  },
  methods:{
    refreshData(){
      axios.get('https://localhost:44334/Product/'+ this.id)
          .then((response) => {
            this.product = response.data;
            console.log(this.product[0])
            
          })
    },
    toCart(){
      //console.log(this.ProductDescription);
      var obj = new Product(this.product[0].productID,this.product[0].productName, this.product[0].productPrice, this.product[0].productImage, this.product[0].productDiscription);
      this.$emit('setProductInCart', obj);
    }




    // refreshData(){
    //   axios.get('https://localhost:44334/Product/'+ this.id)
    //   .then((response )=>{
    //     // this.product = response.data;
    //     this.productNAME = response.data[0].productName
    //     this.productNAME.toString()
    //     console.log(response.data[0].productName)
        
    //   })
      
    // }
  },

  // mounted:function(){
  //   this.refreshData();
  // },
  // },
  //  methods:{
  //   refreshData(){
  //     axios.get('https://localhost:44334/api/Product/{id}')
  //     .then((response)=>{
  //       this.items=response.data;
        
        
  //     });
  //   },
  
};

</script>