using Delas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Model.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetUserByLogin(string login);
        void Add(User user);
        void Save();
        List<Account> GetAllAccountsByLogin(string login);
    }
}
