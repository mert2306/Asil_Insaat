using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Müsteris
{
    public class MüsteriProfil : Profile
    {

        public MüsteriProfil()
        {
            CreateMap<MüsteriViewModel, Müsteri>().ReverseMap();
            CreateMap<MüsteriEklemeViewModel, Müsteri>().ReverseMap();
            CreateMap<MüsteriGuncellemeViewModel, Müsteri>().ReverseMap();
        }
    }
}
