using DBRepository.Models;
using DBRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models;

namespace WebShop.Services
{
    public class AuthenticationService
    {
        WebShopRepository<User> _shopRepository;
        public AuthenticationService()
        {
            _shopRepository = new WebShopRepository<User>();
        }

        public bool IsUserExist(string Name)
        {
            var users = _shopRepository.GetAll();
            if (users.Find(x => x.UserName == Name) != null)
            {
                return false;
            }
            return true;
        }

        public void Register(UserRegisterModel model)
        {

            _shopRepository.Create(new User()
            {
                UserName = model.Name,
                UserPassword = model.Password,
                UserEmail = model.Password
            });

        }

        public User GetUserByName(string Name)
        {
            var users = _shopRepository.GetAll();
            return users.Find(x => x.UserName == Name);
        }
    }
}