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
            AutoMapperInitialize init = new UserSOAP();
            init.InitMapping();
            User user = (User)userRepository.GetUserByLogin(login);
            

            if (user == null)
                return null;

            UserSOAP userResult = new UserSOAP(user.Id, user.Name, user.Surname, user.Login, user.Password, user.PasswordSalt);
            var zmienna = Mapper.Map<User, UserSOAP>(user);
            return userResult; 
        }

        public string GetBankName()
        {
            var xx = userRepository.GetUserByLogin("qwer");
            return "rqrqrq";
        }
    }
}
