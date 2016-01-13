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
    public class HistoryRepository : BaseDbContextRepository<History, DelasEntities>, IHistoryRepository
    {
        public List<History> GetHistoryByIdAccount(int idAccount)
        {
            return Items.Where(x => x.IdAccount.Equals(idAccount)).OrderByDescending(y => y.Date).ToList();
        }
    }
}
