using DBRepository.Models;
using DBRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}