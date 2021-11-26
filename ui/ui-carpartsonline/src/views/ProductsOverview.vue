<template>
  <!-- <div class="card" style="width: 18rem;">
  <img src="../assets/engine-1967.png" class="card-img-top" alt="Test">
  <div class="card-body">
    <h5 class="card-title">Engine</h5>
    <p class="card-text">Product</p>
    <a href="#" class="btn btn-primary">Add to Shoppingcart</a>
  </div>
</div> -->

<Product/>
<!-- <div class="row" style="border: 1px">
    <div class="col-3">
          <ProductCard
            ProductImage=""
            ProductDescription="Part"
            ProductTitle="Part1"
          />
    </div>
</div> -->
</template>

<script>
import Product from '@/components/Product.vue'
// import ProductCard from '@/components/ProductCard.vue'
// import ProductCard from '@/components/ProductCard.vue'
export default{
  components:{
    Product,
    // ProductCard
  },
  
}
// export default {
//    name: 'ProductOverview',
//    components: {
//      ProductCard
//    }
//  }
// export default{
// data(){
//   return{
//     products:[]
//   }
// },
// methods:{
//     refreshData(){
//       axios.get(variables.API_URL+"products")
//       .then((response)=>{
//         this.departments=response.data;
//       });
//     }
// },
// mounted:function(){
//   this.refreshData();
// }
// }
</script>

<style >

</style>
