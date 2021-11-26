<template>

 <!-- <div class="row"> -->
    <div class="card-deck"  >
        <router-link v-for="item in items" :key="item.productID" :to="{ name: 'ProductDetails', params: { id: item.productID} }">
          <div class="card" style="width: 18rem; height: 25em;">
            <img :src="(item.productImage)" class="card-img-top imagesize" alt="Test">
            <div class="card-body">
              <h5 class="card-title">{{item.productName}}</h5>
              <h6 class="card-text">${{item.productPrice}}</h6>
              <p class="card-text">{{item.productDescription}}</p>
              <a href="#" class="btn btn-light addToCart" style="border-top: 5px solid #d9322b; border-bottom: 5px solid #0f6fb7;
  background-color: white; " @add-to-shoppingcart="addShoppingCart(product)"
            :ProductImage="item.productImage"
            :ProductDescription="item.productDescription"
            :ProductTitle="item.productName"
            
            :ProductPrice="item.productPrice"
            :ProductID="item.productID">Add to Shoppingcart</a>
            </div>
          </div>
        </router-link>
    </div>
    <router-view
      v-on:setProductInCart="setShoppingCart"/>
 <!-- </div>  -->
  

  <!-- <table class="table tbale-striped">
    <thead>
      <tr>
          <th>
              ProductId
          </th>
          <th>
            ProductName
          </th>
          <th>
            Options
          </th>
      </tr>
    </thead>
    <tbody>
        <tr v-for="post in posts" :key="post">
          <td>{{post.productID}}</td>
          <td>{{ post.productName }}</td>
          <td>
            <button type="button" class="btn btn-light mr-1">
              <i class="bi bi-pencil-square"></i>
            </button>
          </td>
        </tr>
    </tbody>
  </table> -->


<!-- <table class="table">
    <thead>
    <tr>
      <th scope="col">#ID</th>
      <th scope="col">Product Name</th>
      <th scope="col">Product Price</th>
      <th scope="col">Product Description</th>
      <th scope="col">Adding Date</th>
      <th scope="col">Image (Path)</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="post in posts" :key="post">
      <th scope="row">{{ post.productID }}</th>
      <td>{{ post.productName }}</td>
      <td>{{ post.productPrice }}</td>
      <td>{{ post.description }}</td>
      <td>{{ post.productAddingDate }}</td>
      <td>{{ post.productImage }}</td>
    </tr>
    </tbody>
  </table> -->
</template>
  


<script>

export default {
  
  data(){
    return{
        items:[],
        
        
    }
  },
  methods:{
    refreshData(){
      axios.get('https://localhost:44334/api/Product')
      .then((response)=>{
        this.items= response.data;
        
        
      });
    },
    addShoppingCart(product){
      //modal laten tonen met winkelwagen
      console.log(product);
      if (product){
        this.$emit('setProductInCart', product);
      }
    },
    toCart(){
      //console.log(this.ProductDescription);
      var obj = new Product(this.product[0].productID,this.product[0].productName, this.product[0].productPrice, this.product[0].productImage, this.product[0].productDiscription);
      this.$emit('setProductInCart', obj);
    }
   
    // showProduct(product) {
    //     eventBus.$emit("product", product);
    //     this.$router.push({name: "Product"});
    // }
    // goTodetail(prodId) {
    // this.$router.push({name:'ProductInfo',params:{Pid:prodId}});
    // this.$route.params.Pid;
    
    // },
    
    // showProduct(productId) {
    //     this.selectedProductId = productId;
    //     console.log(this.productId)
    // }
  },
  mounted:function(){
    this.refreshData();
  },
  // computed: {
  //   selectedProduct() {
  //       return this.items.find(item => item.productId === this.selectedProductId)
  //   }

  // mutations: {},
  // actions: {},
  // getters: {
  //   product: (state) => (productId) => {
  //     return state.items.filter(p => p.productId === Number(productId))[0]
  //   }
  // }
}
</script>
<style scoped>
.container{
  display: flex;
  flex-wrap: wrap;
}
.container > div {
padding: 10px;
}
.imagesize{
  height: 191px;
  width: 286px;
}
.addToCart{
  bottom: 0;
 text-align: end;
 
}
</style>