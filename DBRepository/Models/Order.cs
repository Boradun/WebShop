using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Models
{
    public class Order : ItemBase
    {
        public string CustomerName { get; set; } 
        public DateTime OrderDate { get; set; }
        public string NameOfProductList { get; set; }
    }
}
