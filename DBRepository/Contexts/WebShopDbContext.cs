using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Contexts
{
    class WebShopDbContext : DbContext
    {
        public WebShopDbContext() : base("ShopDb")
        {
        }
        internal DbSet<User> Users { get; set; }
        internal DbSet<Product> Products { get; set; }
    }
}
