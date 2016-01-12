using Delas.Site.BankServiceReference;
using Delas.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Delas.Site.Controllers
{
    public class UserController : Controller
    {
        BankServiceClient client = new BankServiceClient("BankServiceEndpoint");
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if(IsValid(user.Login, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login error");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrypPass = crypto.Compute(user.Password);

                UserSOAP newUser = new UserSOAP();
                newUser.Login = user.Login;
                newUser.Password = encrypPass;
                newUser.PasswordSalt = crypto.Salt;
                client.AddUser(newUser);
                FormsAuthentication.SetAuthCookie(user.Login, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Register error");
            }

            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "User");
        }

        private bool IsValid(string login, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;

            UserSOAP user = client.GetUserByLogin(login);

            if(user != null)
            {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}