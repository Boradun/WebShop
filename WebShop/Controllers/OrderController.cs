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
    public class OrderController : Controller
    {
        public static List<OrderListModel> OrdersList { get; set; } = new List<OrderListModel>();
        CatalogService _catalogService;

        public OrderController()
        {
            _catalogService = new CatalogService();
        }
        // GET: Order
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(OrdersList.Where(x => x.UserName == User.Identity.Name).FirstOrDefault());
            }
            return View();
        }

        public ActionResult AddOrderList()
        {
            OrdersList.Add(new OrderListModel() { UserName = User.Identity.Name,OrderedProducts=new List<Product>() });
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Buy(Product product)
        {
            if (User.Identity.IsAuthenticated)
            {
                _catalogService.BuyProduct(product);
                OrderListModel order = OrdersList.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                order.OrderedProducts.Add(product);
                return RedirectToAction("CatalogView", "Catalog");
            }
            return RedirectToAction("Login","Authentication");
        }
    }
}