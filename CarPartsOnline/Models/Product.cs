using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsOnline.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal productPrice { get; set; }
        







    }
}
