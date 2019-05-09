using DBRepository.Contexts;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
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
                // поиск пользователя в бд
                User user = null;
                using (WebShopDbContext db = new WebShopDbContext())
                {
                    user = db.GetUser(model.Name, model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
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
                User user = null;
                using (WebShopDbContext db = new WebShopDbContext())
                {
                    if (!db.IsUserExist(model.Name))
                    {
                        // создаем нового пользователя
                        user = db.AddUser(model.Name, model.Password, model.Email);
                        // если пользователь удачно добавлен в бд
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    }
                }
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
