using DBRepository.Contexts;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Models;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class AuthenticationController : Controller
    {
        AuthenticationService _authenticationService;

        public AuthenticationController()
        {
            _authenticationService = new AuthenticationService();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAuthModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_authenticationService.IsUserExist(model.Name))
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    return View(model);
                }
                var user = _authenticationService.GetUserByName(model.Name);
                if (user.UserPassword == model.Password)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_authenticationService.IsUserExist(model.Name))
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    return View(model);
                }
                _authenticationService.Register(model);
                FormsAuthentication.SetAuthCookie(model.Name, true);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
