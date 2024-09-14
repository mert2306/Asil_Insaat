using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using Asil_Insaat.Entity.ViewModels.Yazis;
using Asil_Insaat.Service.Extensions;
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

    public class UrunController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUrunService urunService;
        private readonly ISatisBirimiService satisBirimiService;
        private readonly IValidator<Ürün> validator;

        public UrunController(IMapper mapper, IUrunService urunService, ISatisBirimiService satisBirimiService, IValidator<Ürün> validator)
        {
            this.mapper = mapper;
            this.urunService = urunService;
            this.satisBirimiService = satisBirimiService;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var urunler = await urunService.SilinmemisTümUrunVeSatisBirinleriniGetirAsync();
            return View(urunler);
        }



        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            var satisBirimleri = await satisBirimiService.SilinmemisTümSatisBirimleriniGetir();
            return View(new ÜrünEklemeViewModel { SatisBirimis = satisBirimleri });
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(ÜrünEklemeViewModel ürünEklemeViewModel)
        {

            await urunService.UrunOlusturAsync(ürünEklemeViewModel);
            return RedirectToAction("Index", "Urun", new { Area = "Admin" });

        }


        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid urunId)
        {
            var urun = await urunService.SilinmemisUrunVeSatisBirimleriniGetirAsync(urunId);
            var satisBirimleri = await satisBirimiService.SilinmemisTümSatisBirimleriniGetir();

            var ürünGüncellemeViewModel = mapper.Map<ÜrünGüncellemeViewModel>(urun);
            ürünGüncellemeViewModel.SatisBirimis = satisBirimleri;

            return View(ürünGüncellemeViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(ÜrünGüncellemeViewModel ürünGüncellemeViewModel)
        {

            var map = mapper.Map<Ürün>(ürünGüncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await urunService.UrunGuncelleAsync(ürünGüncellemeViewModel);
                return RedirectToAction("Index", "Urun", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var satisBirimleri = await satisBirimiService.SilinmemisTümSatisBirimleriniGetir();
            ürünGüncellemeViewModel.SatisBirimis = satisBirimleri;
            return View(ürünGüncellemeViewModel);

        }
        [HttpGet]
        public async Task<IActionResult> Sil(Guid urunId)
        {
             await urunService.UrunGüvenliSilmeAsync(urunId);


            return RedirectToAction("Index", "Urun", new { Area = "Admin" });
        }

    }
}
