using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class AccountSOAP
    {
        public AccountSOAP(int id, int idUser, string number, double balance)
        {
            this.Id = id;
            this.IdUser = IdUser;
            this.Number = number;
            this.Balance = balance;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public double Balance { get; set; }
    }
}
