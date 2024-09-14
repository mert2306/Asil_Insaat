using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using Asil_Insaat.Web.DonutMesajlari;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Asil_Insaat.Web.Areas.Admin.Controlles

{
    [Area("Admin")]

    public class SatisBirimiController : Controller
    {
        private readonly ISatisBirimiService satisBirimiService;
        private readonly IMapper mapper;
        private readonly IValidator<SatisBirimi> validator;

        public SatisBirimiController(ISatisBirimiService satisBirimiService, IMapper mapper, IValidator<SatisBirimi> validator)
        {
            this.satisBirimiService = satisBirimiService;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var satisBirimleri = await satisBirimiService.SilinmemisTümSatisBirimleriniGetir();
            return View(satisBirimleri);
        }


        [HttpGet]
        public async Task<IActionResult> SatisBirimiEkle()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SatisBirimiEkle(SatisBirimiEklemeViewModel satisBirimiEklemeViewModel)
        {
            var map = mapper.Map<SatisBirimi>(satisBirimiEklemeViewModel);

            await satisBirimiService.SatisBirimiOlusturAsync(satisBirimiEklemeViewModel);
            return RedirectToAction("Index", "SatisBirimi", new { Area = "Admin" });

        }

        [HttpPost]

        public async Task<IActionResult> AddWithAjaxSatis([FromBody] SatisBirimiEklemeViewModel satisBirimiEklemeViewModel)
        {

            var map = mapper.Map<SatisBirimi>(satisBirimiEklemeViewModel);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await satisBirimiService.SatisBirimiOlusturAsync(satisBirimiEklemeViewModel);

                return Json(satisBirimiEklemeViewModel.Aciklama);
            }
            else
            {
                return Json(result.Errors.First().ErrorMessage);

            }





        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid satisBirimiId)
        {
            var satis = await satisBirimiService.SatisBirimiGetirByGuid(satisBirimiId);
            var map = mapper.Map<SatisBirimi, SatisBirimiGuncellemeViewModel>(satis);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(SatisBirimiGuncellemeViewModel satisBirimiGuncelleme)
        {



            var name = await satisBirimiService.SatisBirimiGüncelleAsync(satisBirimiGuncelleme);
            return RedirectToAction("Index", "SatisBirimi", new { Area = "Admin" });

        }


        [HttpGet]
        public async Task<IActionResult> SatisBirimiSil()
        {
            var satis = await satisBirimiService.TümSilinmisSatisBirimleriniGetir();
            return View(satis);
        }


        public async Task<IActionResult> Sil(Guid satisBirimiId)
        {

            var isim = await satisBirimiService.SatisBirimleriniGüvenliSilAsync(satisBirimiId);


            return RedirectToAction("Index", "SatisBirimi", new { Area = "Admin" });

        }

        

    }
}
