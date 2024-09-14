using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.SatisBirimis
{
    public class SatisBirimiProfil : Profile
    {

        public SatisBirimiProfil()
        {
            CreateMap<SatisBirimiViewModel, SatisBirimi>().ReverseMap();
            CreateMap<SatisBirimiEklemeViewModel, SatisBirimi>().ReverseMap();
            CreateMap<SatisBirimiGuncellemeViewModel, SatisBirimi>().ReverseMap();
        }
    }
}
