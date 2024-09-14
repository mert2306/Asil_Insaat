using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Entity.ViewModels.Müsteris;
using Asil_Insaat.Entity.ViewModels.SatisBirimi;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using Asil_Insaat.Web.DonutMesajlari;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]

    public class MüsteriController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMüsteriService müsteriService;

        public MüsteriController(IMapper mapper, IMüsteriService müsteriService)
        {
            this.mapper = mapper;
            this.müsteriService = müsteriService;
        }


        public async Task<IActionResult> Index()
        {

            var müsteriler = await müsteriService.SilinmemisTümMüsterilerileriGetir();
            return View(müsteriler);
        }
        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Ekle(MüsteriEklemeViewModel müsteriEklemeViewModel)
        {

            await müsteriService.MüsteriOlusturAsync(müsteriEklemeViewModel);
            return RedirectToAction("Index", "Müsteri", new { Area = "Admin" });


        }


        [HttpGet]
        public async Task<IActionResult> Guncelle(Guid müsteriId)
        {
            var musteri = await müsteriService.MüsteriGetirByGuid(müsteriId);
            var map = mapper.Map<Müsteri, MüsteriGuncellemeViewModel>(musteri);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(MüsteriGuncellemeViewModel müsteriGuncellemeView)
        {


            var map = mapper.Map<Müsteri>(müsteriGuncellemeView);

            var name = await müsteriService.MüsteriGüncelleAsync(müsteriGuncellemeView);
            return RedirectToAction("Index", "Müsteri", new { Area = "Admin" });

        }

        public async Task<IActionResult> Sil(Guid müsteriId)
        {

            await müsteriService.MüsterisGüvenliSilAsync(müsteriId);


            return RedirectToAction("Index", "Müsteri", new { Area = "Admin" });

        }


    }
}
