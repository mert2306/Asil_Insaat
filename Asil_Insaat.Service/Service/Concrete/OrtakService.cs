using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Ortaks;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class OrtakService : IOrtakService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IResimHelper resimHelper;
        private readonly ClaimsPrincipal kullanici;


        public OrtakService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IResimHelper resimHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.resimHelper = resimHelper;
            kullanici = httpContextAccessor.HttpContext.User;

        }

        public async Task<List<OrtakViewModel>> SilinmemisOrtaklariGetirAsync()
        {
            var ortaklar = await unitOfWork.GetRepository<Ortak>().GetAllAsync(x => !x.SilinmisMi, r => r.Resim);
            var map = mapper.Map<List<OrtakViewModel>>(ortaklar);
            return map;
        }

        public async Task OrtakOlusturAsync(OrtakEklemeViewModel ortakEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var resimYükleme = await resimHelper.Upload(ortakEklemeViewModel.Baslik, ortakEklemeViewModel.Ortak, ResimType.Galeri);
            Resim resim = new(resimYükleme.TamIsim, ortakEklemeViewModel.Ortak.ContentType, userEmail);
            await unitOfWork.GetRepository<Resim>().AddAsync(resim);

            var ortak = new Ortak(ortakEklemeViewModel.Baslik, ortakEklemeViewModel.Baglanti, userId, userEmail, ortakEklemeViewModel.fileType, resim.Id);

            ortak.OlusturulmaTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Ortak>().AddAsync(ortak);
            await unitOfWork.SaveAsync();
        }


        public async Task<string> OrtakGüncelleAsync(OrtakGuncellemeViewModel ortakGuncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var foto = await unitOfWork.GetRepository<Ortak>().GetAsync(x => !x.SilinmisMi && x.Id == ortakGuncellemeViewModel.Id, i => i.Resim);

            if (ortakGuncellemeViewModel.Ortak != null)
            {
                resimHelper.Delete(foto.Resim.FileName);
                var resimGüncelle = await resimHelper.Upload(ortakGuncellemeViewModel.Baslik, ortakGuncellemeViewModel.Ortak, ResimType.Ortak);
                Resim resim = new(resimGüncelle.TamIsim, ortakGuncellemeViewModel.Ortak.ContentType, userEmail);
                await unitOfWork.GetRepository<Resim>().AddAsync(resim);

                foto.ResimId = resim.Id;
            }

            foto.Baslik = ortakGuncellemeViewModel.Baslik;
            foto.Baglanti = ortakGuncellemeViewModel.Baglanti;

            foto.Düzenleyen = userEmail;
            foto.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Ortak>().UpdateAsync(foto);
            await unitOfWork.SaveAsync();

            return foto.Baslik;
        }

        public async Task<OrtakViewModel> SilinmemisOrtaklariGetirIdGöreAsync(Guid ortakId)
        {
            var foto = await unitOfWork.GetRepository<Ortak>().GetAsync(x => !x.SilinmisMi && x.Id == ortakId, i => i.Resim);
            var map = mapper.Map<OrtakViewModel>(foto);

            return map;
        }

        public async Task<string> OrtakGüvenliSilmeAsync(Guid ortakId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var fotograf = await unitOfWork.GetRepository<Ortak>().GetByGuidAsync(ortakId);

            fotograf.SilinmisMi = true;
            fotograf.Silen = userEmail;
            fotograf.SilmeTarihi = DateTime.Now;
            await unitOfWork.GetRepository<Ortak>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }

        public async Task<List<OrtakViewModel>> SilimisTümOrtakGetirAsync()
        {
            var Fotos = await unitOfWork.GetRepository<Ortak>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<OrtakViewModel>>(Fotos);

            return map;
        }

        public async Task<string> OrtakGüvenliGeriGetirAsync(Guid ortakId)
        {
            var fotograf = await unitOfWork.GetRepository<Ortak>().GetByGuidAsync(ortakId);

            fotograf.SilinmisMi = false;
            fotograf.Silen = null;
            await unitOfWork.GetRepository<Ortak>().UpdateAsync(fotograf);
            await unitOfWork.SaveAsync();

            return fotograf.Baslik;
        }


    }
}
