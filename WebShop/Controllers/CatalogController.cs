using DBRepository.Contexts;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        CatalogService _catalogService;
        public CatalogController()
        {
            _catalogService = new CatalogService();
        }

        public ActionResult CatalogView()
        {
            return View(new CatalogAllCategoriesModel(_catalogService));
        }

        public ActionResult Category(string CategoryName)
        {
            List<Product> list;
            using (WebShopDbContext db = new WebShopDbContext())
            {
                list = db.GetProductsByCategory(CategoryName);
            }
            List<CatalogOneCategoryModel> viewList = new List<CatalogOneCategoryModel>();
            foreach (var i in list)
            {
                viewList.Add(i);
            }

            return View(viewList);
        }

        public ActionResult ProductView(string ProductName)
        {
            Product product;
            using (WebShopDbContext db = new WebShopDbContext())
            {
                product = db.GetProduct(ProductName);
            }
            return View(product);
        }
    }
}