using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using Asil_Insaat.Service.Extensions;
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
    public class MüsteriService : IMüsteriService

    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ClaimsPrincipal Kullanici;


        public MüsteriService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            Kullanici = httpContextAccessor.HttpContext.User;

        }


        public async Task<Müsteri> MüsteriGetirByGuid(Guid id)
        {
            var müsteri = await unitOfWork.GetRepository<Müsteri>().GetByGuidAsync(id);
            return müsteri;
        }


        public async Task MüsteriOlusturAsync(MüsteriEklemeViewModel müsteriEklemeViewModel)
        {
            
            var userEmail = Kullanici.GetLoggedInEmail();
            Müsteri müsteri =new(müsteriEklemeViewModel.Isim, müsteriEklemeViewModel.Email, müsteriEklemeViewModel.Telefon, müsteriEklemeViewModel.Adres, müsteriEklemeViewModel.Sehir, müsteriEklemeViewModel.PostaKodu, müsteriEklemeViewModel.OdemeSarti, userEmail);
            await unitOfWork.GetRepository<Müsteri>().AddAsync(müsteri);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<MüsteriViewModel>> SilinmemisTümMüsterilerileriGetir()
        {
            var müsteriler = await unitOfWork.GetRepository<Müsteri>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<MüsteriViewModel>>(müsteriler);
            return map;
        }


        public async Task<List<MüsteriViewModel>> SilinmemisTümMüsterileriGetirSıralı()
        {
            var kategoris = await unitOfWork.GetRepository<Müsteri>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<MüsteriViewModel>>(kategoris);

            return map.Take(24).ToList();
        }


        public async Task<string> MüsteriGüncelleAsync(MüsteriGuncellemeViewModel müsteriGuncellemeViewModel)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var müsteri = await unitOfWork.GetRepository<Müsteri>().GetAsync(x => !x.SilinmisMi && x.Id == müsteriGuncellemeViewModel.Id);

            müsteri.Isim = müsteriGuncellemeViewModel.Isim;
            müsteri.Email = müsteriGuncellemeViewModel.Email;
            müsteri.OdemeSarti = müsteriGuncellemeViewModel.OdemeSarti;
            müsteri.Adres = müsteriGuncellemeViewModel.Adres;
            müsteri.Telefon = müsteriGuncellemeViewModel.Telefon;
            müsteri.Sehir = müsteriGuncellemeViewModel.Sehir;
            müsteri.PostaKodu = müsteriGuncellemeViewModel.PostaKodu;
            müsteri.Düzenleyen = userEmail;
            müsteri.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<Müsteri>().UpdateAsync(müsteri);
            await unitOfWork.SaveAsync();
            return müsteri.Isim;
        }

        public async Task<string> MüsterisGüvenliSilAsync(Guid müsteriId)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var müsteri = await unitOfWork.GetRepository<Müsteri>().GetByGuidAsync(müsteriId);

            müsteri.SilinmisMi = true;
            müsteri.SilmeTarihi = DateTime.Now;
            müsteri.Silen = userEmail;
            await unitOfWork.GetRepository<Müsteri>().UpdateAsync(müsteri);
            await unitOfWork.SaveAsync();

            return müsteri.Isim;
        }

    }
}
