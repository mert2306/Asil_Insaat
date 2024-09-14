using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Yazis;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Fotografs
{
    public class FotografProfil : Profile
    {
        public FotografProfil()
        {
            CreateMap<FotografViewModel, Fotograf>().ReverseMap();
            CreateMap<FotografEklmeViewModel, Fotograf>().ReverseMap();
            CreateMap<FotografGuncellemeViewModel, Fotograf>().ReverseMap(); 
            CreateMap<FotografGuncellemeViewModel, FotografViewModel>().ReverseMap();

        }


    }
}
