﻿using AutoMapper;
using Delas.Model.Model;
using Delas.Model.Repository;
using Delas.Model.Repository.Interfaces;
using Delas.Service.Interfaces;
using Delas.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service
{
    public class BankService : IBankService
    {
        IUserRepository userRepository = new UserRepository();
        IAccountRepository accountRepository = new AccountRepository();
        IHistoryRepository historyRepository = new HistoryRepository();

        #region User
        public UserSOAP GetUserByLogin(string login)
        {
            UserSOAP.InitMapping();
            User user = userRepository.GetUserByLogin(login);
            

            if (user == null)
                return null;

            return Mapper.Map<User, UserSOAP>(user);
        }

        public void AddUser(UserSOAP userSOAP)
        {
            UserSOAP.InitMapping();
            userRepository.Add(Mapper.Map<UserSOAP, User>(userSOAP));
        }

        public void Save()
        {
            userRepository.Save();
        }

        public List<AccountSOAP> GetAllAccountsByLogin(string login)
        {
            AccountSOAP.InitMapping();
            List<Account> accountsList = userRepository.GetAllAccountsByLogin(login);

            return Mapper.Map<List<Account>, List<AccountSOAP>>(accountsList);

        }
        
        #endregion

        #region Account
        public void DeleteAccount(int id)
        {
            accountRepository.Delete(id);
        }

        public void AddAccount(AccountSOAP account)
        {
            AccountSOAP.InitMapping();
            accountRepository.Add(Mapper.Map<AccountSOAP, Account>(account));
        }

        public AccountSOAP GetAccountById(int id)
        {
            AccountSOAP.InitMapping();
            var account = accountRepository.GetAccountById(id);
            return Mapper.Map<Account, AccountSOAP>(account);
        }

        public void UpdateAccount(AccountSOAP account)
        {
            AccountSOAP.InitMapping();
            accountRepository.Update(Mapper.Map<AccountSOAP, Account>(account));
        }

        public AccountSOAP GetAccountByNumber(string number)
        {
            AccountSOAP.InitMapping();
            var account = accountRepository.GetAccountByNumber(number);

            if (account == null)
                return null;

            return Mapper.Map<Account, AccountSOAP>(account);
        }
        #endregion

        #region History
        public List<HistorySOAP> GetHistoryByIdAccount(int idAccount)
        {
            HistorySOAP.InitMapping();
            var historyList = historyRepository.GetHistoryByIdAccount(idAccount);
            return Mapper.Map<List<History>, List<HistorySOAP>>(historyList.ToList()); ;
        }

        public void AddHistory(HistorySOAP history)
        {
            HistorySOAP.InitMapping();
            historyRepository.Add(Mapper.Map<HistorySOAP, History>(history));
        }
        #endregion
    }
}
