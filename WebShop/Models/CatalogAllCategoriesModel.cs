using DBRepository.Contexts;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class CatalogAllCategoriesModel
    {
        public CatalogAllCategoriesModel()
        {
            using (WebShopDbContext db = new WebShopDbContext())
            {
                Categories = db.GetAllCategories();
            }
        }
        public List<string> Categories { get; set; }
    }
}