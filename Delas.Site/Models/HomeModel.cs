using AutoMapper;
using Delas.Site.BankServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{

    public class HomePageViewModel
    {
        public UserInformationsViewModel userInformation { get; set; }
        public List<BankAccountViewModel> bankAccount { get; set; }

        public HomePageViewModel(UserInformationsViewModel userInformation, List<BankAccountViewModel> bankAccount)
        {
            this.userInformation = userInformation;
            this.bankAccount = bankAccount;
        }
    }

    public class UserInformationsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }

        public static void InitMapping()
        {
            Mapper.CreateMap<UserSOAP, UserInformationsViewModel>()
                .ForMember(d => d.Name, s => s.MapFrom(m => m.Name))
                .ForMember(d => d.Surname, s => s.MapFrom(m => m.Surname))
                .ForMember(d => d.Login, s => s.MapFrom(m => m.Login));
        }
    }

    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double Balance { get; set; }

        public static void InitMapping()
        {
            Mapper.CreateMap<AccountSOAP, BankAccountViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Number, s => s.MapFrom(m => m.Number))
                .ForMember(d => d.Balance, s => s.MapFrom(m => m.Balance));
        }
    }
}