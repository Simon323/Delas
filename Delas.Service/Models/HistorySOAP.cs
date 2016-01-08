using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class HistorySOAP
    {
        public HistorySOAP(int id, int idAccount, string title, double amount, int operationType, string destinationAccount, double balance, DateTime date)
        {
            this.Id = id;
            this.IdAccount = IdAccount;
            this.Title = title;
            this.Amount = amount;
            this.OperationType = operationType;
            this.DestinationAccount = destinationAccount;
            this.Balance = balance;
            this.Date = date;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdAccount { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public int OperationType { get; set; }
        [DataMember]
        public string DestinationAccount { get; set; }
        [DataMember]
        public double Balance { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
    }
}
