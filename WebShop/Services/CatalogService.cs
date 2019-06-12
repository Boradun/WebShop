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
                if (i.ProductCategory.Equals(Name))
                    result.Add(new CatalogOneCategoryModel()
                    {
                        ProductImage = i.ProductImage,
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

        public void BuyProduct(Product productToUpdate)
        {
            var _products = _shopRepository.GetAll();
            var _item = _products.Where(x => x.ProductName == productToUpdate.ProductName).FirstOrDefault();
            if (_item != null)
            {
                _item.ProductQuantity -= productToUpdate.ProductQuantity;
                _shopRepository.Update(_item);
            }
        }

        public List<Product> Search(string value)
        {
            List<Product> _list = _shopRepository.GetAll().Where(x =>
              x.ProductCategory.Contains(value) ||
              x.ProductDescription.Contains(value) ||
              x.ProductName.Contains(value)).ToList();
            return _list;
        }

        public List<Product> GetRandomList()
        {
            var _list = _shopRepository.GetAll();
            Random random = new Random();
            List<Product> resultList = new List<Product>();
            for (int i = 0; i < 12; i++)
            {
                resultList.Add(_list[random.Next(_list.Count)]);
            }
            return resultList;
        }
    }
}