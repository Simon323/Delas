using Delas.Model.Model;
using Delas.Model.Repository;
using Delas.Model.Repository.Interfaces;
using Delas.Rest.Models;
using Delas.Rest.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Delas.Rest
{
    public class BankRESTService : IBankRESTService
    {
        public string DoWork()
        {
            return "Welcome";
        }

        public Response Transfer(Transfer model)
        {
            string message = "";
            Response response = new Response();
            IAccountRepository accountRepository = new AccountRepository();
            IHistoryRepository historyRepository = new HistoryRepository();

            bool isSourceAddresCorrect = VerifyAccountNumber(model.source);
            bool isDestinyAddresCorrect = VerifyAccountNumber(model.source);

            if(!isSourceAddresCorrect || !isDestinyAddresCorrect)
            {
                message = "Niepoprawny adres konta";
                return response;
            }

            Account sourceAccount = accountRepository.GetAccountByNumber(model.source);
            Account destinyAccount = accountRepository.GetAccountByNumber(model.destination);
            double amount = Convert.ToDouble(model.amount) / 100;
            double balanceAfterOpperation = sourceAccount.Balance - amount;

            if (amount <= 0 || balanceAfterOpperation < 0)
            {
                message = "Nieodpowiednia kwota";
                return response;
            }

            
            Account sourceAccountToUpdate = new Account();
            Account destinyAccountToUpdate = new Account();
            History sourceAccountHistory = new History();
            History destinyAccountHistory = new History();

            sourceAccountToUpdate.Id = sourceAccount.Id;
            sourceAccountToUpdate.Balance = balanceAfterOpperation;

            destinyAccountToUpdate.Id = destinyAccount.Id;
            destinyAccountToUpdate.Balance = destinyAccount.Balance + amount;

            sourceAccountHistory.IdAccount = sourceAccount.Id;
            sourceAccountHistory.Title = model.title;
            sourceAccountHistory.Amount = amount * (-1);
            sourceAccountHistory.OperationType = "Przelew";
            sourceAccountHistory.DestinationAccount = destinyAccount.Number;
            sourceAccountHistory.Balance = sourceAccountToUpdate.Balance;
            sourceAccountHistory.Date = DateTime.Now;

            destinyAccountHistory.IdAccount = destinyAccount.Id;
            destinyAccountHistory.Title = model.title;
            destinyAccountHistory.Amount = amount;
            destinyAccountHistory.OperationType = "Przelew";
            destinyAccountHistory.DestinationAccount = sourceAccount.Number;
            destinyAccountHistory.Balance = destinyAccount.Balance;
            destinyAccountHistory.Date = DateTime.Now;

            accountRepository.Update(sourceAccountToUpdate);
            accountRepository.Update(destinyAccountToUpdate);

            historyRepository.Add(sourceAccountHistory);
            historyRepository.Add(destinyAccountHistory);


            response.message = "OK";
            return response;
        }

        private bool VerifyAccountNumber(string accountNumber)
        {
            bool isCorrect = true;
            string nrb = accountNumber.Substring(0, 2);

            if (!Utils.CalculateNRB(accountNumber.Substring(2, accountNumber.Length - 2)).Equals(nrb))
                isCorrect = false;

            return isCorrect;
        }
    }
}
