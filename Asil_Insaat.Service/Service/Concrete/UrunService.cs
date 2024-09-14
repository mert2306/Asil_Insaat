using Asil_Insaat.Data.Context;
using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.Enums;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using Asil_Insaat.Entity.ViewModels.Yazis;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Helpers.Resims;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class UrunService : IUrunService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext appDbContext;
        private readonly ClaimsPrincipal kullanici;

        public UrunService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            kullanici = httpContextAccessor.HttpContext.User;
            this.appDbContext = appDbContext;
        }


        public async Task<Ürün> UrunleriGetirByGuid(Guid id)
        {
            var urun = await unitOfWork.GetRepository<Ürün>().GetByGuidAsync(id);
            return urun;
        }

        public async Task UrunOlusturAsync(ÜrünEklemeViewModel ürünEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var Urun = new Ürün
            {
                Aciklama = ürünEklemeViewModel.Aciklama,
                Baslik = ürünEklemeViewModel.Baslik,
                UrunTuru = ürünEklemeViewModel.UrunTuru,
                Icerik = ürünEklemeViewModel.Icerik,
                Fiyat = ürünEklemeViewModel.Fiyat,
                Kdv = ürünEklemeViewModel.Kdv,
               
                SatisBirimiId = ürünEklemeViewModel.SatisBirimiId,
                Düzenleyen = userEmail,
                DüzenlemeTarihi = DateTime.Now,
                UserId = userId
            };

            await unitOfWork.GetRepository<Ürün>().AddAsync(Urun);
            await unitOfWork.SaveAsync();
        }


        public async Task<List<ÜrünViewModel>> SilinmemisTümUrunVeSatisBirinleriniGetirAsync()
        {
            var urunler = await unitOfWork.GetRepository<Ürün>().GetAllAsync(x => !x.SilinmisMi, x => x.SatisBirimi);
            var map = mapper.Map<List<ÜrünViewModel>>(urunler);

            return map;
        }

        public async Task<ÜrünViewModel> SilinmemisUrunVeSatisBirimleriniGetirAsync(Guid urunId)
        {
            var urun = await unitOfWork.GetRepository<Ürün>().GetAsync(x => !x.SilinmisMi && x.Id == urunId , x => x.SatisBirimi);
            var map = mapper.Map<ÜrünViewModel>(urun);

            return map;
        }

        public async Task<string> UrunGuncelleAsync(ÜrünGüncellemeViewModel ürünGüncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var Urun = await unitOfWork.GetRepository<Ürün>().GetAsync(x => !x.SilinmisMi && x.Id == ürünGüncellemeViewModel.Id, x => x.SatisBirimi);

           

            Urun.Baslik = ürünGüncellemeViewModel.Baslik;
            Urun.SatisBirimiId = ürünGüncellemeViewModel.SatisBirimiId;
            Urun.Icerik = ürünGüncellemeViewModel.Icerik;
            Urun.Fiyat = ürünGüncellemeViewModel.Fiyat;
            Urun.UrunTuru= ürünGüncellemeViewModel.UrunTuru;
            Urun.Kdv = ürünGüncellemeViewModel.Kdv;   
            Urun.Düzenleyen = userEmail;
            Urun.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Ürün>().UpdateAsync(Urun);
            await unitOfWork.SaveAsync();

            return Urun.Baslik;
        }
        public async Task<string> UrunGüvenliSilmeAsync(Guid urunId)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var urun = await unitOfWork.GetRepository<Ürün>().GetByGuidAsync(urunId);

            urun.SilinmisMi = true;
            urun.Silen = userEmail;
            urun.SilmeTarihi = DateTime.Now;
            await unitOfWork.GetRepository<Ürün>().UpdateAsync(urun);
            await unitOfWork.SaveAsync();

            return urun.Baslik;
        }

    }
}
