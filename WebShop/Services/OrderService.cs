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

        public void Buy(OrderListModel model)
        {

        }
    }
}