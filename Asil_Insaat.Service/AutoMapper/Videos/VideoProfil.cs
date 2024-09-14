using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Videos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.AutoMapper.Videos
{
    public class VideoProfil : Profile
    {
        public VideoProfil()
        {
            CreateMap<VideoViewModel, Video>().ReverseMap();
            CreateMap<VideoEklemeViewModel, Video>().ReverseMap();
            CreateMap<VideoGüncellemeViewModel, Video>().ReverseMap();
            CreateMap<VideoGüncellemeViewModel, VideoViewModel>().ReverseMap();

        }
    }
}
