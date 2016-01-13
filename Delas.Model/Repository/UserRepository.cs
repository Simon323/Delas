using Delas.DBContext.Repository;
using Delas.Model.Model;
using Delas.Model.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Model.Repository
{
    public class UserRepository : BaseDbContextRepository<User, DelasEntities>, IUserRepository
    {
        public User GetUserByLogin(string login)
        {
            return Items.FirstOrDefault(x => x.Login.Equals(login));
        }

        public void Add(User user)
        {
            Entities.Users.Add(user);
            Entities.SaveChanges();
        }

        public List<Account> GetAllAccountsByLogin(string login)
        {
            return Items.FirstOrDefault(x => x.Login.Equals(login)).Accounts.ToList();
        }
    }
}
