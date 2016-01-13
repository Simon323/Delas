using Delas.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Model.Repository.Interfaces
{
    public interface IHistoryRepository
    {
        List<History> GetHistoryByIdAccount(int idAccount);
        void Add(History history);
    }
}
