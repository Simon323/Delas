using AutoMapper;
using Delas.Site.BankServiceReference;
using Delas.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delas.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        BankServiceClient client = new BankServiceClient("BankServiceEndpoint");
        public ActionResult Index()
        {
            UserInformationsViewModel.InitMapping();
            BankAccountViewModel.InitMapping();
            var userLogin = User.Identity.Name;
            var userInformations = client.GetUserByLogin(userLogin);
            var bankAccounts = client.GetAllAccountsByLogin(userLogin);
            
            HomePageViewModel model = new HomePageViewModel(Mapper.Map<UserSOAP, UserInformationsViewModel>(userInformations), Mapper.Map<List<AccountSOAP>, List<BankAccountViewModel>>(bankAccounts.ToList()));

            return View(model);
        }

        public ActionResult History(int id)
        {
            return View();
        }

        public ActionResult DeleteAccount(int id)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Transfer()
        {
            return View();
        }

        public ActionResult CashHandout() // wypłata
        {
            return View();
        }

        public ActionResult Contribution() //wpłata
        {
            return View();
        }
    }
}