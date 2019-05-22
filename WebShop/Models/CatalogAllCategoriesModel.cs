using DBRepository.Contexts;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Services;

namespace WebShop.Models
{
    public class CatalogAllCategoriesModel
    {
        public List<string> Categories { get; set; }
    }
}