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
    public partial class HistorySOAP
    {
        public HistorySOAP(int id, int idAccount, string title, double amount, string operationType, string destinationAccount, double balance, DateTime date)
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
        public string OperationType { get; set; }
        [DataMember]
        public string DestinationAccount { get; set; }
        [DataMember]
        public double Balance { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }

        public static void InitMapping()
        {
            Mapper.CreateMap<History, HistorySOAP>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IdAccount, s => s.MapFrom(m => m.IdAccount))
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Amount, s => s.MapFrom(m => m.Amount))
                .ForMember(d => d.OperationType, s => s.MapFrom(m => m.OperationType))
                .ForMember(d => d.DestinationAccount, s => s.MapFrom(m => string.IsNullOrEmpty(m.DestinationAccount) ? "" : m.DestinationAccount))
                .ForMember(d => d.Balance, s => s.MapFrom(m => m.Balance))
                .ForMember(d => d.Date, s => s.MapFrom(m => m.Date));

            Mapper.CreateMap<HistorySOAP, History>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IdAccount, s => s.MapFrom(m => m.IdAccount))
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Amount, s => s.MapFrom(m => m.Amount))
                .ForMember(d => d.OperationType, s => s.MapFrom(m => m.OperationType))
                .ForMember(d => d.DestinationAccount, s => s.MapFrom(m => m.DestinationAccount))
                .ForMember(d => d.Balance, s => s.MapFrom(m => m.Balance))
                .ForMember(d => d.Date, s => s.MapFrom(m => m.Date));
        }
    }
}
