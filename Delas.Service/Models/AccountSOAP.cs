using AutoMapper;
using Delas.Model.Model;
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

        public static void InitMapping()
        {
            Mapper.CreateMap<Account, AccountSOAP>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IdUser, s => s.MapFrom(m => m.IdUser))
                .ForMember(d => d.Number, s => s.MapFrom(m => m.Number))
                .ForMember(d => d.Balance, s => s.MapFrom(m => m.Balance));

            Mapper.CreateMap<AccountSOAP, Account>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IdUser, s => s.MapFrom(m => m.IdUser))
                .ForMember(d => d.Number, s => s.MapFrom(m => m.Number))
                .ForMember(d => d.Balance, s => s.MapFrom(m => m.Balance));
        }
    }
}
