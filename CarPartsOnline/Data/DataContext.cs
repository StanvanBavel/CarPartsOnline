using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPartsOnline.Models;

using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;

namespace CarPartsOnline.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }

        public DbSet<Product> Products { get; set; }
        

    }
}
