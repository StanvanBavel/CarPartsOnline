<template>
<div>
   <h1>Create Product</h1>
     <div class="card-body">
                        <form @submit="submitProduct">
                        <strong>Name:</strong>
                        <input type="text" class="form-control" v-model="productName">
                        <strong>Price:</strong>
                        <input type="text" class="form-control" v-model="productPrice">
                        <strong>Description:</strong>
                        <textarea class="form-control" v-model="productDescription"></textarea>
                        <strong>ImageLink:</strong>
                        <input type="text" class="form-control" v-model="productImage">
    
                        <button class="btn btn-success">Submit</button>
                        </form>
                        <strong>Output:</strong>
                        <pre>
                        {{this.output}}
                        </pre>
                    </div>
</div>	
</template>
<script>
    export default{
        data () {
    return {
            
            productName: '',
      productDescription: '',
      productPrice: '',
      productImage: '',
      output: ''

        
    }
  },
  methods:{
        submitProduct(e){
            axios.post('https://localhost:44334/Product/Create', {
                productName: this.productName,
                productDescription: this.productDescription,
                productPrice: this.productPrice,
                productImage: this.productImage,
          })
            .then((response)=>{
                this.output = response.data
                
            })
            
            .catch((error)=>{
                this.output = error;
            })
            
        }
    }
    }
</script>
<style scoped>

</style>
