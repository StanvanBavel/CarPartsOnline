using CarPartsOnline.Data;
using CarPartsOnline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DataContext db;
        public ProductController(DataContext db)
        {
            this.db = db;
        }


        [HttpGet]

          public IActionResult GetAllProducts()
        {
            var products = db.Products.ToList();
            return Ok(products);
        }

        [Route("/[controller]/{id}")]
        [HttpGet]
        public string GetProductByID(int id)
        {
            var byId = from Product in db.Products
                        where Product.productID == id
                        select Product;
            return JsonConvert.SerializeObject(byId);
        }
        [Route("/[controller]/Create")]
        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        [Route("/[controller]/Delete")]
        public string DeleteProductByID(int productid)
        {
            Product product = db.Products.Where(x => x.productID == productid).Single<Product>();
            db.Products.Remove(product);
            db.SaveChanges();
            return "Product has succesfully been Deleted";
        }
        [Authorize]
        [HttpPut]
        [Route("/[controller]/Update")]
        public string EditProduct(Product mode)
        {
            Product product = db.Products.Where(x => x.productID == mode.productID).Single<Product>();
            product.productID = mode.productID;
            product.productName = mode.productName;
            product.productDescription = mode.productDescription;
            product.productPrice = mode.productPrice;
            product.productImage = mode.productImage;
            db.Entry(product).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Product has been Updated";
        }

    }
}
