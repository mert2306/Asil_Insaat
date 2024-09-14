using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Yazis;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class FotografService : IFotografService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IResimHelper resimHelper;
        private readonly ClaimsPrincipal kullanici;

        public FotografService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IResimHelper resimHelper)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.resimHelper = resimHelper;
            kullanici = httpContextAccessor.HttpContext.User;
        }


        public async Task<List<FotografViewModel>> SilinmemisFotograflariiGetirAsync()
        {
            var fotolar = await unitOfWork.GetRepository<Fotograf>().GetAllAsync(x => !x.SilinmisMi, r => r.Resim);
            var map = mapper.Map<List<FotografViewModel>>(fotolar);
            return map;
        }

        public async Task FotografOlusturAsync(FotografEklmeViewModel fotografEklmeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var resimYükleme = await resimHelper.Upload(fotografEklmeViewModel.Baslik, fotografEklmeViewModel.Fotograf, ResimType.Referans);
            Resim resim = new(resimYükleme.TamIsim, fotografEklmeViewModel.Fotograf.ContentType, userEmail);
            await unitOfWork.GetRepository<Resim>().AddAsync(resim);

            var foto = new Fotograf(fotografEklmeViewModel.Baslik, fotografEklmeViewModel.Icerik, userId,userEmail,fotografEklmeViewModel.fileType, resim.Id);

            foto.OlusturulmaTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Fotograf>().AddAsync(foto);
            await unitOfWork.SaveAsync();
        }


        public async Task<string> FotografGüncelleAsync(FotografGuncellemeViewModel fotografGuncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var foto = await unitOfWork.GetRepository<Fotograf>().GetAsync(x => !x.SilinmisMi && x.Id == fotografGuncellemeViewModel.Id, i => i.Resim);

            if (fotografGuncellemeViewModel.Fotograf != null)
            {
                resimHelper.Delete(foto.Resim.FileName);
                var resimGüncelle = await resimHelper.Upload(fotografGuncellemeViewModel.Baslik, fotografGuncellemeViewModel.Fotograf, ResimType.Referans);
                Resim resim = new(resimGüncelle.TamIsim, fotografGuncellemeViewModel.Fotograf.ContentType, userEmail);
                await unitOfWork.GetRepository<Resim>().AddAsync(resim);

                foto.ResimId = resim.Id;
            }

            foto.Baslik = fotografGuncellemeViewModel.Baslik;
            foto.İcerik = fotografGuncellemeViewModel.İcerik;
            
            foto.Düzenleyen = userEmail;
            foto.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Fotograf>().UpdateAsync(foto);
            await unitOfWork.SaveAsync();

            return foto.Baslik;
        }

        public async Task<FotografViewModel> SilinmemisFotograflariGetirAsync(Guid fotografId)
        {
            var foto = await unitOfWork.GetRepository<Fotograf>().GetAsync(x => !x.SilinmisMi && x.Id == fotografId, i => i.Resim);
            var map = mapper.Map<FotografViewModel>(foto);

            return map;
        }

        public async Task<string> FotografGüvenliSilmeAsync(Guid fotografId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var fotograf = await unitOfWork.GetRepository<Fotograf>().GetByGuidAsync(fotografId);

            fotograf.SilinmisMi = true;
            fotograf.Silen = userEmail;
            fotograf.SilmeTarihi = DateTime.Now;
            await unitOfWork.GetRepository<Fotograf>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }

        public async Task<List<FotografViewModel>> SilimisTümFotograflariGetirAsync()
        {
            var Fotos = await unitOfWork.GetRepository<Fotograf>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<FotografViewModel>>(Fotos);

            return map;
        }

        public async Task<string> FotografGüvenliGetirAsync(Guid fotografId)
        {
            var fotograf = await unitOfWork.GetRepository<Fotograf>().GetByGuidAsync(fotografId);

            fotograf.SilinmisMi = false;
            fotograf.Silen = null;
            await unitOfWork.GetRepository<Fotograf>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }

    }
}
