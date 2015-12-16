using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class Account
    {
        public Account()
        {
            this.Histories = new HashSet<History>();
        }

        public Account(int id, int idUser, string number, double balance)
        {
            this.Histories = new HashSet<History>();
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
        [DataMember]
        public virtual User User { get; set; }
        [DataMember]
        public virtual ICollection<History> Histories { get; set; }
    }
}
