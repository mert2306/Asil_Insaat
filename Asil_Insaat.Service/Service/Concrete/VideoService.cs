using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Videos;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IResimHelper resimHelper;
        private readonly ClaimsPrincipal kullanici;


        public VideoService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IResimHelper resimHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.resimHelper = resimHelper;
            kullanici = httpContextAccessor.HttpContext.User;

        }


        public async Task<List<VideoViewModel>> SilinmemisVideolariGetirAsync()
        {
            var videolar = await unitOfWork.GetRepository<Video>().GetAllAsync(x => !x.SilinmisMi, r => r.Resim);
            var map = mapper.Map<List<VideoViewModel>>(videolar);
            return map;
        }
        public async Task VideoOlusturAsync(VideoEklemeViewModel videoEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var resimYükleme = await resimHelper.Upload(videoEklemeViewModel.Baslik, videoEklemeViewModel.Video, ResimType.Video);
            Resim resim = new(resimYükleme.TamIsim, videoEklemeViewModel.Video.ContentType, userEmail);
            await unitOfWork.GetRepository<Resim>().AddAsync(resim);

            var video = new Video(videoEklemeViewModel.Baslik, videoEklemeViewModel.Icerik, userId, userEmail, videoEklemeViewModel.fileType, resim.Id);

            video.OlusturulmaTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Video>().AddAsync(video);
            await unitOfWork.SaveAsync();
        }

        public async Task<string> VideoGüncelleAsync(VideoGüncellemeViewModel videoGüncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var foto = await unitOfWork.GetRepository<Video>().GetAsync(x => !x.SilinmisMi && x.Id == videoGüncellemeViewModel.Id, i => i.Resim);

            if (videoGüncellemeViewModel.Video != null)
            {
                resimHelper.Delete(foto.Resim.FileName);
                var resimGüncelle = await resimHelper.Upload(videoGüncellemeViewModel.Baslik, videoGüncellemeViewModel.Video, ResimType.Video);
                Resim resim = new(resimGüncelle.TamIsim, videoGüncellemeViewModel.Video.ContentType, userEmail);
                await unitOfWork.GetRepository<Resim>().AddAsync(resim);

                foto.ResimId = resim.Id;
            }

            foto.Baslik = videoGüncellemeViewModel.Baslik;
            foto.İcerik = videoGüncellemeViewModel.İcerik;

            foto.Düzenleyen = userEmail;
            foto.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Video>().UpdateAsync(foto);
            await unitOfWork.SaveAsync();

            return foto.Baslik;
        }
        public async Task<VideoViewModel> SilinmemisVideolariGetirIdGöreAsync(Guid videoId)
        {
            var foto = await unitOfWork.GetRepository<Video>().GetAsync(x => !x.SilinmisMi && x.Id == videoId, i => i.Resim);
            var map = mapper.Map<VideoViewModel>(foto);

            return map;
        }


        public async Task<string> VideoGüvenliSilmeAsync(Guid videoId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var fotograf = await unitOfWork.GetRepository<Video>().GetByGuidAsync(videoId);

            fotograf.SilinmisMi = true;
            fotograf.Silen = userEmail;
            fotograf.SilmeTarihi = DateTime.Now;
            await unitOfWork.GetRepository<Video>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }

        public async Task<List<VideoViewModel>> SilimisTümVideolariGetirAsync()
        {
            var Fotos = await unitOfWork.GetRepository<Video>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<VideoViewModel>>(Fotos);

            return map;
        }

        public async Task<string> VideoGüvenliGetirAsync(Guid videoId)
        {
            var fotograf = await unitOfWork.GetRepository<Video>().GetByGuidAsync(videoId);

            fotograf.SilinmisMi = false;
            fotograf.Silen = null;
            await unitOfWork.GetRepository<Video>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }
    }
}
