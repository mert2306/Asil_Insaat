using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Ortaks;
using AutoMapper;

namespace Asil_Insaat.Service.AutoMapper.Ortaks
{
    public class OrtakProfil : Profile
    {
        public OrtakProfil()
        {
            CreateMap<OrtakViewModel, Ortak>().ReverseMap();
            CreateMap<OrtakEklemeViewModel, Ortak>().ReverseMap();
            CreateMap<OrtakGuncellemeViewModel, Ortak>().ReverseMap();
            CreateMap<OrtakGuncellemeViewModel, OrtakViewModel>().ReverseMap();
        }
    }
}
