using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Users
{
    public class UserProfil : Profile
    {
        public UserProfil()
        {
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppUser, UserEklemeViewModel>().ReverseMap();
            CreateMap<AppUser, UserGüncellemeViewModel>().ReverseMap();
            CreateMap<AppUser, UserProfilViewModel>().ReverseMap();


        }

    }
}
