using Delas.Model.Repository;
using Delas.Model.Repository.Interfaces;
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

        public User GetUserByLogin(string login)
        {
            var user = userRepository.GetUserByLogin(login);

            if (user == null)
                return null;

            User userResult = new User(user.Id, user.Name, user.Surname, user.Login, user.Password, user.PasswordSalt);

            return userResult;
        }

        public string GetBankName()
        {
            var xx = userRepository.GetUserByLogin("qwer");
            return "rqrqrq";
        }
    }
}
