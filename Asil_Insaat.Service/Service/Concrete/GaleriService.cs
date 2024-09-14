using Asil_Insaat.Data.Mappings;
using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Galeris;
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
    public class GaleriService  : IGaleriService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IResimHelper resimHelper;
        private readonly ClaimsPrincipal kullanici;


        public GaleriService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IResimHelper resimHelper )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.resimHelper = resimHelper;
            kullanici = httpContextAccessor.HttpContext.User;

        }

        public async Task<List<GaleriViewModel>> SilinmemisGaleriGetirAsync()
        {
            var videolar = await unitOfWork.GetRepository<Galeri>().GetAllAsync(x => !x.SilinmisMi, r => r.Resim);
            var map = mapper.Map<List<GaleriViewModel>>(videolar);
            return map;
        }
        public async Task GaleriOlusturAsync(GaleriEklemeViewModel galeriEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var resimYükleme = await resimHelper.Upload(galeriEklemeViewModel.Baslik, galeriEklemeViewModel.Galeri, ResimType.Galeri);
            Resim resim = new(resimYükleme.TamIsim, galeriEklemeViewModel.Galeri.ContentType, userEmail);
            await unitOfWork.GetRepository<Resim>().AddAsync(resim);

            var video = new Galeri(galeriEklemeViewModel.Baslik, galeriEklemeViewModel.Icerik, userId, userEmail, galeriEklemeViewModel.fileType, resim.Id);

            video.OlusturulmaTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Galeri>().AddAsync(video);
            await unitOfWork.SaveAsync();
        }

        public async Task<string> GaleriGüncelleAsync(GaleriGuncellemeViewModel galeriGuncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var foto = await unitOfWork.GetRepository<Galeri>().GetAsync(x => !x.SilinmisMi && x.Id == galeriGuncellemeViewModel.Id, i => i.Resim);

            if (galeriGuncellemeViewModel.Galeri != null)
            {
                resimHelper.Delete(foto.Resim.FileName);
                var resimGüncelle = await resimHelper.Upload(galeriGuncellemeViewModel.Baslik, galeriGuncellemeViewModel.Galeri, ResimType.Galeri);
                Resim resim = new(resimGüncelle.TamIsim, galeriGuncellemeViewModel.Galeri.ContentType, userEmail);
                await unitOfWork.GetRepository<Resim>().AddAsync(resim);

                foto.ResimId = resim.Id;
            }

            foto.Baslik = galeriGuncellemeViewModel.Baslik;
            foto.İcerik = galeriGuncellemeViewModel.İcerik;

            foto.Düzenleyen = userEmail;
            foto.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Galeri>().UpdateAsync(foto);
            await unitOfWork.SaveAsync();

            return foto.Baslik;
        }

        public async Task<GaleriViewModel> SilinmemisGaleriGetirIdGöreAsync(Guid galeriId)
        {
            var foto = await unitOfWork.GetRepository<Galeri>().GetAsync(x => !x.SilinmisMi && x.Id == galeriId, i => i.Resim);
            var map = mapper.Map<GaleriViewModel>(foto);

            return map;
        }
        public async Task<string> GaleriGüvenliSilmeAsync(Guid galeriId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var fotograf = await unitOfWork.GetRepository<Galeri>().GetByGuidAsync(galeriId);

            fotograf.SilinmisMi = true;
            fotograf.Silen = userEmail;
            fotograf.SilmeTarihi = DateTime.Now;
            await unitOfWork.GetRepository<Galeri>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }
        public async Task<List<GaleriViewModel>> SilimisTümGaleriGetirAsync()
        {
            var Fotos = await unitOfWork.GetRepository<Galeri>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<GaleriViewModel>>(Fotos);

            return map;
        }

        public async Task<string> GaleriGüvenliGeriGetirAsync(Guid galeriId)
        {
            var fotograf = await unitOfWork.GetRepository<Galeri>().GetByGuidAsync(galeriId);

            fotograf.SilinmisMi = false;
            fotograf.Silen = null;
            await unitOfWork.GetRepository<Galeri>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }
    }
}
