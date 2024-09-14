using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Teklifs;
using Asil_Insaat.Entity.ViewModels.Yazis;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Teklifs
{
    public class TeklifProfil : Profile
    {
        public TeklifProfil()
        {
            CreateMap<TeklifViewModel, Teklif>().ReverseMap();
            CreateMap<TeklifGuncellemeViewModel, Teklif>().ReverseMap();
            CreateMap<TeklifGuncellemeViewModel, TeklifViewModel>().ReverseMap();
            CreateMap<TeklifEklemeViewModel, Teklif>().ReverseMap();
        }
    }
}
