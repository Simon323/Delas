using AutoMapper;
using Delas.Site.BankServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class HistoryViewModel
    {
        public int IdAccount { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string OperationType { get; set; }
        public string DestinationAccount { get; set; }
        public double Balance { get; set; }
        public DateTime Date { get; set; }

        public static void InitMapping()
        {
            Mapper.CreateMap<HistorySOAP, HistoryViewModel>()
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