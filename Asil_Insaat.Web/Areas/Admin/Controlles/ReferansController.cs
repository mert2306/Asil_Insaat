using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{

    [Area("Admin")]
    public class ReferansController : Controller
    {
        private readonly IFotografService fotografService;
        private readonly IMapper mapper;
        private readonly IValidator<Fotograf> validator;

        public ReferansController(IFotografService fotografService, IMapper mapper, IValidator<Fotograf> validator)
        {
            this.fotografService = fotografService;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {

            var fotolar = await fotografService.SilinmemisFotograflariiGetirAsync();
            return View(fotolar);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(FotografEklmeViewModel fotografEklmeViewModel )
        {

            var map = mapper.Map<Fotograf>(fotografEklmeViewModel);

            var result = await validator.ValidateAsync(map);

           

                await fotografService.FotografOlusturAsync(fotografEklmeViewModel);
                return RedirectToAction("Index", "Referans", new { Area = "Admin" });

           
            
        }
        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid fotografId)
        {
            var foto = await fotografService.SilinmemisFotograflariGetirAsync(fotografId);

            var fotografGuncellemeViewModel = mapper.Map<FotografGuncellemeViewModel>(foto);

            return View(fotografGuncellemeViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Güncelle(FotografGuncellemeViewModel fotografGuncellemeViewModel)
        {

            var map = mapper.Map<Fotograf>(fotografGuncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                var baslik = await fotografService.FotografGüncelleAsync(fotografGuncellemeViewModel);
                return RedirectToAction("Index", "Referans", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            return View(fotografGuncellemeViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid fotografId)
        {
            var baslik = await fotografService.FotografGüvenliSilmeAsync(fotografId);


            return RedirectToAction("Index", "Referans", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> ReferansSil()
        {
            var fotograflar = await fotografService.SilimisTümFotograflariGetirAsync();

            return View(fotograflar);
        }

        [HttpGet]
        public async Task<IActionResult> GeriSilme(Guid fotografId)
        {

            var baslik = await fotografService.FotografGüvenliGetirAsync(fotografId);


            return RedirectToAction("Index", "Referans", new { Area = "Admin" });

        }




    }
}
