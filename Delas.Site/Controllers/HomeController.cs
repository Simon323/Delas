using AutoMapper;
using Delas.Site.BankServiceReference;
using Delas.Site.Models;
using Delas.Site.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            HistoryViewModel.InitMapping();
            var history = client.GetHistoryByIdAccount(id);
            List<HistoryViewModel> model = Mapper.Map<List<HistorySOAP>, List<HistoryViewModel>>(history.ToList()); 

            return View(model);
        }

        public ActionResult CreateAccount()
        {
            AccountSOAP newAccount = new AccountSOAP();
            var user = client.GetUserByLogin(User.Identity.Name);

            newAccount.IdUser = user.Id;
            newAccount.Number = Utils.GenerateNewAccountNumber();
            newAccount.Balance = 0.0;

            client.AddAccount(newAccount);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteAccount(int id)
        {
            client.DeleteAccount(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Transfer()
        {
            return View();
        }

        public ActionResult CashHandout(int id) // wypłata
        {
            PaymentViewModel model = new PaymentViewModel(id, 0.0);
            return View(model);
        }

        [HttpPost]
        public ActionResult CashHandout(PaymentViewModel model) // wypłata
        {
            if (ModelState.IsValid)
            {
                var account = client.GetAccountById(model.IdAccount);
                double balanceAfterOpperation = account.Balance - model.Amount;

                if (model.Amount <= 0 || balanceAfterOpperation < 0)
                {
                    ModelState.AddModelError("", "Incorect Amount");
                    return View(model);
                }

                AccountSOAP accountToUpdate = new AccountSOAP();
                accountToUpdate.Id = model.IdAccount;
                accountToUpdate.Balance = balanceAfterOpperation;

                HistorySOAP history = new HistorySOAP();
                history.IdAccount = model.IdAccount;
                history.Title = "Wypłata własna";
                history.Amount = model.Amount * (-1);
                history.OperationType = "Wypłata";
                history.Balance = accountToUpdate.Balance;
                history.Date = DateTime.Now;

                client.UpdateAccount(accountToUpdate);
                client.AddHistory(history);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorect Amount");
            return View(model);
        }

        public ActionResult Contribution(int id) //wpłata
        {
            PaymentViewModel model = new PaymentViewModel(id, 0.0);
            return View(model);
        }

        [HttpPost]
        public ActionResult Contribution(PaymentViewModel model) //wpłata
        {
            if (ModelState.IsValid)
            {
                if(model.Amount <= 0)
                {
                    ModelState.AddModelError("", "Incorect Amount");
                    return View(model);
                }

                var account = client.GetAccountById(model.IdAccount);
                AccountSOAP accountToUpdate = new AccountSOAP();
                accountToUpdate.Id = model.IdAccount;
                accountToUpdate.Balance = account.Balance + model.Amount;

                HistorySOAP history = new HistorySOAP();
                history.IdAccount = model.IdAccount;
                history.Title = "Wpłata własna";
                history.Amount = model.Amount;
                history.OperationType = "Wpłata";
                history.Balance = accountToUpdate.Balance;
                history.Date = DateTime.Now;

                client.UpdateAccount(accountToUpdate);
                client.AddHistory(history);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorect Amount");
            return View(model);
        }
    }
}