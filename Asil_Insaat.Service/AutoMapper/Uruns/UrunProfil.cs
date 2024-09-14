using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using Asil_Insaat.Entity.ViewModels.Yazis;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Uruns
{
    public class UrunProfil : Profile
    {
        public UrunProfil()
        {
            CreateMap<ÜrünViewModel, Ürün>().ReverseMap();
            CreateMap<ÜrünGüncellemeViewModel, Ürün>().ReverseMap();
            CreateMap<ÜrünGüncellemeViewModel, ÜrünViewModel>().ReverseMap();
            CreateMap<ÜrünEklemeViewModel, Ürün>().ReverseMap();
        }
    }
    
}
