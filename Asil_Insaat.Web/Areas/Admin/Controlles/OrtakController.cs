using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Galeris;
using Asil_Insaat.Entity.ViewModels.Ortaks;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]

    public class OrtakController : Controller
    {
        private readonly IOrtakService ortakService;
        private readonly IMapper mapper;
        private readonly IValidator<Ortak> validator;

        public OrtakController(IOrtakService ortakService, IMapper mapper, IValidator<Ortak> validator)
        {
            this.ortakService = ortakService;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var ortak = await ortakService.SilinmemisOrtaklariGetirAsync();
            return View(ortak);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(OrtakEklemeViewModel ortakEklemeViewModel)
        {

            var map = mapper.Map<Ortak>(ortakEklemeViewModel);




            await ortakService.OrtakOlusturAsync(ortakEklemeViewModel);
            return RedirectToAction("Index", "Ortak", new { Area = "Admin" });



        }

        [HttpGet]
        public async Task<IActionResult> Guncelle(Guid ortakId)
        {
            var ortak = await ortakService.SilinmemisOrtaklariGetirIdGöreAsync(ortakId);

            var ortakGuncellemeViewModel = mapper.Map<OrtakGuncellemeViewModel>(ortak);

            return View(ortakGuncellemeViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(OrtakGuncellemeViewModel ortakGuncellemeViewModel)
        {

            var map = mapper.Map<Ortak>(ortakGuncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                var baslik = await ortakService.OrtakGüncelleAsync(ortakGuncellemeViewModel);
                return RedirectToAction("Index", "Ortak", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            return View(ortakGuncellemeViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid ortakId)
        {
            var baslik = await ortakService.OrtakGüvenliSilmeAsync(ortakId);


            return RedirectToAction("Index", "Ortak", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> OrtakSil()
        {
            var fotograflar = await ortakService.SilimisTümOrtakGetirAsync();

            return View(fotograflar);
        }

        [HttpGet]
        public async Task<IActionResult> GeriSilme(Guid galeriId)
        {

            var baslik = await ortakService.OrtakGüvenliGeriGetirAsync(galeriId);


            return RedirectToAction("Index", "Ortak", new { Area = "Admin" });

        }
    }
}

