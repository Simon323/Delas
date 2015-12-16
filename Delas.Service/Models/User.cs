using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class User
    {
        public User()
        {
            this.Accounts = new HashSet<Account>();
        }

        public User(int id, string name, string surname, string login, string password, string passwordSalt)
        {
            this.Accounts = new HashSet<Account>();
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Password = password;
            this.PasswordSalt = passwordSalt;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string PasswordSalt { get; set; }
        [DataMember]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
