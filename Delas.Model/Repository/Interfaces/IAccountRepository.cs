using Delas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Model.Repository.Interfaces
{
    public interface IAccountRepository
    {
        void Delete(int id);
        void Add(Account account);
    }
}
