using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class OrderListModel
    {
        public OrderListModel()
        {
            OrderId = DateTime.Now.ToString();
        }
        public string OrderId { get; set; }
        public string UserName { get; set; }
        public List<Product> OrderedProducts { get; set; }
    }
}