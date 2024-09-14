using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Teklifs;
using Asil_Insaat.Entity.ViewModels.Ürüns;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{


    [Area("Admin")]

    

    public class TeklifController : Controller
    {
        private readonly ITeklifService teklifService;
        private readonly IMapper mapper;
        private readonly IUrunService urunService;
        private readonly IMüsteriService müsteriService;
        private readonly IValidator<Teklif> validator;

        public TeklifController(ITeklifService teklifService, IMapper mapper, IUrunService urunService, IMüsteriService müsteriService, IValidator<Teklif> validator)
        {
            this.teklifService = teklifService;
            this.mapper = mapper;
            this.urunService = urunService;
            this.müsteriService = müsteriService;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {

            var teklfler = await teklifService.SilinmemisTümTeklifMüsteriVeUrunleriGetirAsync();
            return View(teklfler);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            var urunler = await urunService.SilinmemisTümUrunVeSatisBirinleriniGetirAsync();
            var müsteriler = await müsteriService.SilinmemisTümMüsterilerileriGetir();

            return View(new TeklifEklemeViewModel { Ürüns = urunler, Müsteris = müsteriler });
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(TeklifEklemeViewModel teklifEklemeViewModel)
        {

            await teklifService.TeklifOlusturAsync(teklifEklemeViewModel);
            return RedirectToAction("Index", "Teklif", new { Area = "Admin" });

        }


        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid teklifId)
        {
            var teklif = await teklifService.SilinmemisTeklifUrunVeMüsterileriGetirAsync(teklifId);
            var müsteri = await müsteriService.SilinmemisTümMüsterilerileriGetir();
            var urun = await urunService.SilinmemisTümUrunVeSatisBirinleriniGetirAsync();

            var teklifGuncellemeView = mapper.Map<TeklifGuncellemeViewModel>(teklif);
            teklifGuncellemeView.Ürüns = urun;
            teklifGuncellemeView.Müsteris = müsteri;

            return View(teklifGuncellemeView);

        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(TeklifGuncellemeViewModel teklifGuncellemeViewModel)
        {

            var map = mapper.Map<Teklif>(teklifGuncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await teklifService.TeklifGuncelleAsync(teklifGuncellemeViewModel);
                return RedirectToAction("Index", "Teklif", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var urunler = await urunService.SilinmemisTümUrunVeSatisBirinleriniGetirAsync();
            var müsteriler = await müsteriService.SilinmemisTümMüsterilerileriGetir();
            teklifGuncellemeViewModel.Ürüns = urunler;
            teklifGuncellemeViewModel.Müsteris = müsteriler;
            return View(teklifGuncellemeViewModel);

        }

    }
}
