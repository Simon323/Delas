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
        void AddUser(UserSOAP userSOAP);

        [OperationContract]
        void Save();

        [OperationContract]
        List<AccountSOAP> GetAllAccountsByLogin(string login);

        #region Account
        [OperationContract]
        void DeleteAccount(int id);

        [OperationContract]
        void AddAccount(AccountSOAP account);
        #endregion

        #region History
        [OperationContract]
        List<HistorySOAP> GetHistoryByIdAccount(int idAccount);
        #endregion
    }
}
