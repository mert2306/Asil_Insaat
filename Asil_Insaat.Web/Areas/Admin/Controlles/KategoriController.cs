using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using Asil_Insaat.Web.DonutMesajlari;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Web.WebPages;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{

    [Area("Admin")]

    public class KategoriController : Controller
    {
        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<Kategori> validator;

        public KategoriController(IKategoriService kategoriService, IMapper mapper, IToastNotification toastNotification, IValidator<Kategori> validator)
        {
            this.kategoriService = kategoriService;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();
            return View(kategoriler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(KategoriEklemeViewModel kategoriEklemeViewModel)
        {
            var map = mapper.Map<Kategori>(kategoriEklemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await kategoriService.KategoriOlusturAsync(kategoriEklemeViewModel);
                return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

            }


            result.AddToModelState(this.ModelState);

            return View();

        }



        [HttpPost]

        public async Task<IActionResult> AddWithAjax([FromBody] KategoriEklemeViewModel kategoriEklemeViewModel)
        {

            var map = mapper.Map<Kategori>(kategoriEklemeViewModel);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {

                await kategoriService.KategoriOlusturAsync(kategoriEklemeViewModel);
                toastNotification.AddSuccessToastMessage(Messages.Kategori.Ekle(kategoriEklemeViewModel.Isim), new ToastrOptions { Title = "başarılı!" });

                return Json(Messages.Kategori.Ekle(kategoriEklemeViewModel.Isim));

            }
            else
            {
                toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "Başarısız!" });
                return Json(result.Errors.First().ErrorMessage);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid kategoriId)
        {
            var kategori = await kategoriService.KategoriGetirByGuid(kategoriId);
            var map = mapper.Map<Kategori, KategoriGüncellemeViewModel>(kategori);
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Güncelle(KategoriGüncellemeViewModel kategoriGüncellemeViewModel)
        {
            var map = mapper.Map<Kategori>(kategoriGüncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                await kategoriService.KategoriGüncelleAsync(kategoriGüncellemeViewModel);
                return RedirectToAction("Index", "Kategori", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(kategoriGüncellemeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> KategoriSil()
        {
            var kategoriler = await kategoriService.TümSilinmisKAtegorileriGetir();
            return View(kategoriler);
        }


        public async Task<IActionResult> Sil(Guid kategoriId)
        {

            await kategoriService.KategorileriGüvenliSilAsync(kategoriId);


            return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

        }


        public async Task<IActionResult> GeriSilme(Guid kategoriId)
        {

            await kategoriService.SilinenKategoriGeriGetirAsync(kategoriId);


            return RedirectToAction("Index", "Kategori", new { Area = "Admin" });

        }




    }
}
