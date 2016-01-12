using AutoMapper;
using Delas.Model.Model;
using Delas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Delas.Service.Models
{
    [DataContract]
    public partial class UserSOAP// : AutoMapperInitialize
    {

        public UserSOAP() { }
        public UserSOAP(int id, string name, string surname, string login, string password, string passwordSalt)
        {
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

        public static void InitMapping()
        {
            Mapper.CreateMap<User, UserSOAP>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Name, s => s.MapFrom(m => m.Name))
                .ForMember(d => d.Surname, s => s.MapFrom(m => m.Surname))
                .ForMember(d => d.Login, s => s.MapFrom(m => m.Login))
                .ForMember(d => d.Password, s => s.MapFrom(m => m.Password))
                .ForMember(d => d.PasswordSalt, s => s.MapFrom(m => m.PasswordSalt));

            Mapper.CreateMap<UserSOAP, User>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Name, s => s.MapFrom(m => m.Name))
                .ForMember(d => d.Surname, s => s.MapFrom(m => m.Surname))
                .ForMember(d => d.Login, s => s.MapFrom(m => m.Login))
                .ForMember(d => d.Password, s => s.MapFrom(m => m.Password))
                .ForMember(d => d.PasswordSalt, s => s.MapFrom(m => m.PasswordSalt));
        }
    }
}
