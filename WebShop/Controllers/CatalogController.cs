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
            return View(new CatalogAllCategoriesModel()
            { Categories = _catalogService.GetAllCategories() });
        }

        public ActionResult CategoryView(string CategoryName)
        {
            List<CatalogOneCategoryModel> viewList = _catalogService.GetOneCategory(CategoryName);
            return View(viewList);
        }

        public ActionResult ProductView(string ProductName)
        {
            Product product = _catalogService.GetProductByName(ProductName);
            return View(product);
        }
    }
}