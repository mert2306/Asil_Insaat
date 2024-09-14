using Asil_Insaat.Data.Context;
using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Teklifs;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Asil_Insaat.Service.Service.Concrete
{
    public class TeklifService : ITeklifService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppDbContext appDbContext;
        private readonly ClaimsPrincipal kullanici;


        public TeklifService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.appDbContext = appDbContext;
            kullanici = httpContextAccessor.HttpContext.User;

        }
        public async Task<Teklif> TeklifleriGetirByGuid(Guid id)
        {
            var teklif = await unitOfWork.GetRepository<Teklif>().GetByGuidAsync(id);
            return teklif;
        }

        public async Task<List<TeklifViewModel>> SilinmemisTümTeklifMüsteriVeUrunleriGetirAsync()
        {
            var teklifler = await unitOfWork.GetRepository<Teklif>().GetAllAsync(x => !x.SilinmisMi, x => x.Müsteri, u => u.Ürün);
            var map = mapper.Map<List<TeklifViewModel>>(teklifler);

            return map;
        }

        public async Task TeklifOlusturAsync(TeklifEklemeViewModel teklifEklemeViewModel)
        {
            var userId = kullanici.GetLoggedInUserId();
            var userEmail = kullanici.GetLoggedInEmail();

            var teklif = new Teklif
            {
                Aciklama = teklifEklemeViewModel.Aciklama,
                Fiyat = teklifEklemeViewModel.Fiyat,
                TeklifTarih = teklifEklemeViewModel.TeklifTarih,
                SonTarih = teklifEklemeViewModel.SonTarih,
                ÜrünId = teklifEklemeViewModel.ÜrünId,
                MüsteriId = teklifEklemeViewModel.MüsteriId,
                OlusturulmaTarihi = teklifEklemeViewModel.OlusturulmaTarihi,
                Oluşturan = userEmail,
                Düzenleyen = userEmail,
                DüzenlemeTarihi = DateTime.Now,
                UserId = userId
            };

            await unitOfWork.GetRepository<Teklif>().AddAsync(teklif);
            await unitOfWork.SaveAsync();
        }

        public async Task<TeklifViewModel> SilinmemisTeklifUrunVeMüsterileriGetirAsync(Guid teklifId)
        {
            var teklif = await unitOfWork.GetRepository<Teklif>().GetAsync(x => !x.SilinmisMi && x.Id == teklifId, x => x.Ürün, m => m.Müsteri);
            var map = mapper.Map<TeklifViewModel>(teklif);

            return map;
        }

        public async Task<string> TeklifGuncelleAsync(TeklifGuncellemeViewModel teklifGuncellemeViewModel)
        {
            var userEmail = kullanici.GetLoggedInEmail();
            var teklif = await unitOfWork.GetRepository<Teklif>().GetAsync(x => !x.SilinmisMi && x.Id == teklifGuncellemeViewModel.Id, x => x.Ürün, m=>m.Müsteri);

            teklif.Aciklama = teklifGuncellemeViewModel.Aciklama;
            teklif.MüsteriId = teklifGuncellemeViewModel.MüsteriId;
            teklif.ÜrünId   = teklifGuncellemeViewModel.ÜrünId;
            teklif.Fiyat = teklifGuncellemeViewModel.Fiyat;
            teklif.TeklifTarih= DateTime.Now;
            teklif.SonTarih=teklifGuncellemeViewModel.SonTarih;
            teklif.Düzenleyen = userEmail;
            teklif.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Teklif>().UpdateAsync(teklif);
            await unitOfWork.SaveAsync();

            return teklif.Aciklama;
        }



    }
}
