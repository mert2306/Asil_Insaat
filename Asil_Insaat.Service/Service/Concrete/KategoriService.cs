using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class KategoriService : IKategoriService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ClaimsPrincipal Kullanici;

        public KategoriService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            Kullanici = httpContextAccessor.HttpContext.User;
        }

        public async Task<Kategori> KategoriGetirByGuid(Guid id)
        {
            var kategori = await unitOfWork.GetRepository<Kategori>().GetByGuidAsync(id);
            return kategori;
        }

        public async Task KategoriOlusturAsync(KategoriEklemeViewModel kategoriEklemeViewModel)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            Kategori kategori = new(kategoriEklemeViewModel.Isim, userEmail);
            await unitOfWork.GetRepository<Kategori>().AddAsync(kategori);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<KategoriViewModel>> SilinmemisTümKategorileriGetir()
        {
            var kategoriler = await unitOfWork.GetRepository<Kategori>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<KategoriViewModel>>(kategoriler);
            return map;
        }

        public async Task<List<KategoriViewModel>> SilinmemisTümKategorileriGetirSıralı()
        {
            var kategoris = await unitOfWork.GetRepository<Kategori>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<KategoriViewModel>>(kategoris);

            return map.Take(24).ToList();
        }

        public async Task<string> KategoriGüncelleAsync(KategoriGüncellemeViewModel kategoriGüncellemeViewModel)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var kategori = await unitOfWork.GetRepository<Kategori>().GetAsync(x => !x.SilinmisMi && x.Id == kategoriGüncellemeViewModel.Id);

            kategori.Isim = kategoriGüncellemeViewModel.Isim;
            kategori.Düzenleyen = userEmail;
            kategori.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Kategori>().UpdateAsync(kategori);
            await unitOfWork.SaveAsync();
            return kategori.Isim;
        }

        public async Task<List<KategoriViewModel>> TümSilinmisKAtegorileriGetir()
        {
            var kategoris = await unitOfWork.GetRepository<Kategori>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<KategoriViewModel>>(kategoris);
            return map;
        }

        public async Task<string> KategorileriGüvenliSilAsync(Guid kategoriId)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var kategori = await unitOfWork.GetRepository<Kategori>().GetByGuidAsync(kategoriId);

            kategori.SilinmisMi = true;
            kategori.SilmeTarihi = DateTime.Now;
            kategori.Silen = userEmail;
            await unitOfWork.GetRepository<Kategori>().UpdateAsync(kategori);
            await unitOfWork.SaveAsync();

            return kategori.Isim;
        }

        public async Task<string> SilinenKategoriGeriGetirAsync(Guid kategoriId)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var kategori = await unitOfWork.GetRepository<Kategori>().GetByGuidAsync(kategoriId);

            kategori.SilinmisMi = false;
            kategori.SilmeTarihi = null;
            kategori.Silen = null;
            await unitOfWork.GetRepository<Kategori>().UpdateAsync(kategori);
            await unitOfWork.SaveAsync();

            return kategori.Isim;
        }
    }
}
