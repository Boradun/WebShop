using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Models
{
    public class ProductOrderList : ItemBase
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public string NameOfList { get; set; }
    }
}
