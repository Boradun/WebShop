using DBRepository.Models;
using DBRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.Services
{
    public class CatalogService
    {
        WebShopRepository<Product> _shopRepository;
        public CatalogService()
        {
            _shopRepository = new WebShopRepository<Product>();
        }

        public List<string> GetAllCategories()
        {
            return _shopRepository.GetAll().Select(x => x.ProductCategory).Distinct().ToList();
        }

        public List<CatalogOneCategoryModel> GetOneCategory(string Name)
        {
            var list = _shopRepository.GetAll();
            List<CatalogOneCategoryModel> result = new List<CatalogOneCategoryModel>();
            foreach (var i in list)
            {
                if(i.ProductCategory.Equals(Name))
                result.Add(new CatalogOneCategoryModel()
                {
                    ProductName = i.ProductName,
                    ProductPrice = i.ProductPrice
                });
            }
            return result;
        }

        public Product GetProductByName(string Name)
        {
            return _shopRepository.GetAll().Where(x => x.ProductName == Name).FirstOrDefault();
        }
    }
}