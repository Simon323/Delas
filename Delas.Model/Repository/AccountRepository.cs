using Delas.DBContext.Repository;
using Delas.Model;
using Delas.Model.Model;
using Delas.Model.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Model.Repository
{
    public class AccountRepository : BaseDbContextRepository<Account, DelasEntities>, IAccountRepository
    {
        public void Delete(int id)
        {
            var account = Items.FirstOrDefault(x => x.Id.Equals(id));
            Entities.Accounts.Remove(account);
            Entities.SaveChanges();
        }

        public void Add(Account account)
        {
            Entities.Accounts.Add(account);
            Entities.SaveChanges();
        }

        public Account GetAccountById(int id)
        {
            return Items.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Update(Account account)
        {
            var accountToUpdate = Items.FirstOrDefault(x => x.Id.Equals(account.Id));
            accountToUpdate.Balance = account.Balance;
            Entities.SaveChanges();
        }

        public Account GetAccountByNumber(string number)
        {
            return Items.FirstOrDefault(x => x.Number.Equals(number));
        }
    }
}
