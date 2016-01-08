using Delas.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        UserSOAP GetUserByLogin(string login);

        [OperationContract]
        string GetBankName();
    }
}
