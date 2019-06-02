using DBRepository.Models;
using DBRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.Services
{
    public class OrderService
    {
        WebShopRepository<Order> _orderRepository;
        WebShopRepository<ProductOrderList> _orderListRepository;
        public OrderService()
        {
            _orderRepository = new WebShopRepository<Order>();
            _orderListRepository = new WebShopRepository<ProductOrderList>();
        }

        public void ApplyOrder(OrderListModel model)
        {
            DateTime dateTime = DateTime.Now;
            _orderRepository.Create(new Order()
            {
                CustomerName = model.UserName,
                OrderDate = DateTime.Now,
                NameOfProductList = model.UserName + "_" + dateTime.ToString()
            });
            foreach (var i in model.OrderedProducts)
            {
                _orderListRepository.Create(new ProductOrderList()
                {
                    NameOfList = model.UserName + "_" + dateTime.ToString(),
                    ProductName = i.ProductName,
                    ProductQuantity=i.ProductQuantity
                });
            }
        }
    }
}