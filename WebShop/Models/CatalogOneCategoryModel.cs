using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class CatalogOneCategoryModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public static implicit operator CatalogOneCategoryModel(Product product)
        {
            return new CatalogOneCategoryModel() { ProductName = product.ProductName, ProductPrice = product.ProductPrice };
        }
    }
}