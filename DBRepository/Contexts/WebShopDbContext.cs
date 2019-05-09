using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Contexts
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext() : base("ShopDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public User GetUser(string name, string password)
        {
            return Users.FirstOrDefault(u => u.UserName == name && u.UserPassword == password);
        }

        public bool IsUserExist(string name)
        {
            return Users.Any(x => x.UserName == name);
        }

        public User AddUser(string name, string password, string Email)
        {
            Users.Add(new User() { UserName = name, UserPassword = password, UserEmail = Email });
            SaveChanges();
            return Users.FirstOrDefault(x => x.UserName == name && x.UserPassword == password);
        }

        public List<string> GetAllCategories()
        {
            List<string> list = Products.Select(x => x.ProductCategory).Distinct().ToList();
            return list;
        }

        public List<Product> GetProductsByCategory(string Category)
        {
            return Products.Where(x => x.ProductCategory == Category).ToList();
        }

        public Product GetProduct(string name)
        {
            return Products.FirstOrDefault(x => x.ProductName == name);
        }

        public Product GetProduct(int Id)
        {
            return Products.FirstOrDefault(x => x.ProductId == Id);
        }
    }
}
