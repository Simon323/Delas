using AutoMapper;
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

        public UserSOAP GetUserByLogin(string login)
        {
            //AutoMapperInitialize init = new UserSOAP();
            //init.InitMapping();
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

        public string GetBankName()
        {
            var xx = userRepository.GetUserByLogin("qwer");
            return "rqrqrq";
        }
    }
}
