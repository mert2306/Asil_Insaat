using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Galeris;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Galeris
{
    public class GaleriProfil : Profile
    {
        public GaleriProfil()
        {
            CreateMap<GaleriViewModel, Galeri>().ReverseMap();
            CreateMap<GaleriEklemeViewModel, Galeri>().ReverseMap();
            CreateMap<GaleriGuncellemeViewModel, Galeri>().ReverseMap();
            CreateMap<GaleriGuncellemeViewModel, GaleriViewModel>().ReverseMap();
        }
    }
}
