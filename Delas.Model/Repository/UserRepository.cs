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
    }
}
