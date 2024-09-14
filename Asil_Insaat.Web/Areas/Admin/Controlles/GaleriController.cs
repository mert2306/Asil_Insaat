using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Galeris;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]
    public class GaleriController : Controller
    {
        private readonly IGaleriService galeriService;
        private readonly IMapper mapper;
        private readonly IValidator<Galeri> validator;

        public GaleriController(IGaleriService galeriService, IMapper mapper, IValidator<Galeri> validator)
        {
            this.galeriService = galeriService;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task <IActionResult> Index()
        {
            var galeri = await galeriService.SilinmemisGaleriGetirAsync();
            return View(galeri);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(GaleriEklemeViewModel galeriEklemeViewModel)
        {

            var map = mapper.Map<Galeri>(galeriEklemeViewModel);

            var result = await validator.ValidateAsync(map);



            await galeriService.GaleriOlusturAsync(galeriEklemeViewModel);
            return RedirectToAction("Index", "Galeri", new { Area = "Admin" });



        }

        [HttpGet]
        public async Task<IActionResult> Guncelle(Guid galeriID)
        {
            var foto = await galeriService.SilinmemisGaleriGetirIdGöreAsync(galeriID);

            var galeriGuncellemeViewModel = mapper.Map<GaleriGuncellemeViewModel>(foto);

            return View(galeriGuncellemeViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(GaleriGuncellemeViewModel galeriGuncellemeViewModel)
        {

            var map = mapper.Map<Galeri>(galeriGuncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                var baslik = await galeriService.GaleriGüncelleAsync(galeriGuncellemeViewModel);
                return RedirectToAction("Index", "Galeri", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            return View(galeriGuncellemeViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid galeriId)
        {
            var baslik = await galeriService.GaleriGüvenliSilmeAsync(galeriId);


            return RedirectToAction("Index", "Galeri", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> GaleriSil()
        {
            var fotograflar = await galeriService.SilimisTümGaleriGetirAsync();

            return View(fotograflar);
        }

        [HttpGet]
        public async Task<IActionResult> GeriSilme(Guid galeriId)
        {

            var baslik = await galeriService.GaleriGüvenliGeriGetirAsync(galeriId);


            return RedirectToAction("Index", "Galeri", new { Area = "Admin" });

        }

    }
}
