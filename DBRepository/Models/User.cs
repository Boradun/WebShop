using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Models
{
    public class User
    {
        public User()
        {
            UserId = DateTime.Now.ToString();
        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
    }
}
