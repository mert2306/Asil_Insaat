using Asil_Insaat.Data.UnitOfWorks;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
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
    public class SatisBirimiService : ISatisBirimiService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ClaimsPrincipal Kullanici;


        public SatisBirimiService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            Kullanici = httpContextAccessor.HttpContext.User;

        }

        public async Task<SatisBirimi> SatisBirimiGetirByGuid(Guid id)
        {
            var satisBirimi = await unitOfWork.GetRepository<SatisBirimi>().GetByGuidAsync(id);
            return satisBirimi;

        }

        public async Task SatisBirimiOlusturAsync(SatisBirimiEklemeViewModel SatisBirimiEklemeViewModel)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            SatisBirimi satisBirimi = new(SatisBirimiEklemeViewModel.Aciklama);
            await unitOfWork.GetRepository<SatisBirimi>().AddAsync(satisBirimi);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<SatisBirimiViewModel>> SilinmemisTümSatisBirimleriniGetir()
        {
            var satisBirimleri = await unitOfWork.GetRepository<SatisBirimi>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<SatisBirimiViewModel>>(satisBirimleri);
            return map;
        }

        public async Task<List<SatisBirimiViewModel>> SilinmemisTümSatisBirimleriniGetirSıralı()
        {
            var satisBirimleri = await unitOfWork.GetRepository<SatisBirimi>().GetAllAsync(x => !x.SilinmisMi);
            var map = mapper.Map<List<SatisBirimiViewModel>>(satisBirimleri);

            return map.Take(24).ToList();
        }


        public async Task<string> SatisBirimiGüncelleAsync(SatisBirimiGuncellemeViewModel satisBirimiGuncellemeViewModel)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var satisBirimi = await unitOfWork.GetRepository<SatisBirimi>().GetAsync(x => !x.SilinmisMi && x.Id == satisBirimiGuncellemeViewModel.Id);

            satisBirimi.Aciklama = satisBirimiGuncellemeViewModel.Aciklama;
            satisBirimi.Düzenleyen = userEmail;
            satisBirimi.DüzenlemeTarihi = DateTime.Now;


            await unitOfWork.GetRepository<SatisBirimi>().UpdateAsync(satisBirimi);
            await unitOfWork.SaveAsync();
            return satisBirimi.Aciklama;
        }

        public async Task<List<SatisBirimiViewModel>> TümSilinmisSatisBirimleriniGetir()
        {
            var satisBirimleri = await unitOfWork.GetRepository<SatisBirimi>().GetAllAsync(x => x.SilinmisMi);
            var map = mapper.Map<List<SatisBirimiViewModel>>(satisBirimleri);
            return map;
        }


        public async Task<string> SatisBirimleriniGüvenliSilAsync(Guid satisBirimiId)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var satisBirimi = await unitOfWork.GetRepository<SatisBirimi>().GetByGuidAsync(satisBirimiId);

            satisBirimi.SilinmisMi = true;
            satisBirimi.SilmeTarihi = DateTime.Now;
            satisBirimi.Silen = userEmail;
            await unitOfWork.GetRepository<SatisBirimi>().UpdateAsync(satisBirimi);
            await unitOfWork.SaveAsync();

            return satisBirimi.Aciklama;
        }

        public async Task<string> SilinenSatisBirimleriniGeriGetirAsync(Guid satisBirimiId)
        {
            var userEmail = Kullanici.GetLoggedInEmail();
            var satisBirimi = await unitOfWork.GetRepository<SatisBirimi>().GetByGuidAsync(satisBirimiId);

            satisBirimi.SilinmisMi = false;
            satisBirimi.SilmeTarihi = null;
            satisBirimi.Silen = null;
            await unitOfWork.GetRepository<SatisBirimi>().UpdateAsync(satisBirimi);
            await unitOfWork.SaveAsync();

            return satisBirimi.Aciklama;
        }

    }
}
