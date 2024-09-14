using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Yazis;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Yazilar
{
    public class YaziProfil : Profile
    {
        public YaziProfil()
        {
            CreateMap<YaziViewModel, Yazi>().ReverseMap();
            CreateMap<YaziGüncellemeViewModel, Yazi>().ReverseMap();
            CreateMap<YaziGüncellemeViewModel, YaziViewModel>().ReverseMap();
            CreateMap<YaziEklemeViewModel, Yazi>().ReverseMap();
        }

    }
}
