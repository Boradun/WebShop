using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        CatalogService _catalogService;

        public HomeController()
        {
            _catalogService = new CatalogService();
        }

        public ActionResult Index()
        {
            var list = _catalogService.GetRandomList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}