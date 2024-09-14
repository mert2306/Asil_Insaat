using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Kategoriler
{
    public class KategoriProfil : Profile
    {
        public KategoriProfil()
        {
            CreateMap<KategoriViewModel, Kategori>().ReverseMap();
            CreateMap<KategoriEklemeViewModel, Kategori>().ReverseMap();
            CreateMap<KategoriGüncellemeViewModel, Kategori>().ReverseMap();
        }
    }
}
