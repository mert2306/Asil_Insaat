using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Yazis;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Web.DonutMesajlari;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]

    public class YaziController : Controller
    {
        private readonly IYaziService yaziService;
        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;
        private readonly IValidator<Yazi> validator;
        private readonly IToastNotification notification;

        public YaziController(IYaziService yaziService, IKategoriService kategoriService, IMapper mapper, IValidator<Yazi> validator, IToastNotification notification)
        {
            this.yaziService = yaziService;
            this.kategoriService = kategoriService;
            this.mapper = mapper;
            this.validator = validator;
            this.notification = notification;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var yazilar = await yaziService.SilinmemisTümYaziVeKategorileriGetirAsync();

            return View(yazilar);
        }
        

     
        
        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();
            return View(new YaziEklemeViewModel { Kategoris = kategoriler });
        }
       
        [HttpPost]
        public async Task<IActionResult> Ekle(YaziEklemeViewModel yaziEklemeViewModel)
        {
            var map = mapper.Map<Yazi>(yaziEklemeViewModel);

            if (!await yaziService.BaslikBenzersizMiAsync(yaziEklemeViewModel.Baslik))
            {
                ModelState.AddModelError("Baslik", "Bu içerik zaten var.");
            }

            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await yaziService.YaziOlusturAsync(yaziEklemeViewModel);
                notification.AddSuccessToastMessage(Messages.Yazi.Ekle(yaziEklemeViewModel.Baslik), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Yazi", new { Area = "Admin" });
            }
            else
            {
                var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();
                return View(new YaziEklemeViewModel { Kategoris = kategoriler });
            }
        }




        [HttpGet]
        public async Task<IActionResult> Güncelle(string baslik)
        {
            var yazi = await yaziService.SilinmemisYaziVeKategorileriGetirAsync(baslik);
            var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();

            var yaziGüncellemeViewModel = mapper.Map<YaziGüncellemeViewModel>(yazi);
            yaziGüncellemeViewModel.Kategoris = kategoriler;

            return View(yaziGüncellemeViewModel);

        }   

        [HttpPost]
        public async Task<IActionResult> Güncelle(YaziGüncellemeViewModel yaziGüncellemeViewModel)
        {

            var map = mapper.Map<Yazi>(yaziGüncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                var baslik = await yaziService.YaziGüncelleAsync(yaziGüncellemeViewModel);
                notification.AddInfoToastMessage(Messages.Yazi.Güncelle(baslik), new ToastrOptions { Title = "İşlem Başarılı!" });
                return RedirectToAction("Index", "Yazi", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var kategoriler = await kategoriService.SilinmemisTümKategorileriGetir();
            yaziGüncellemeViewModel.Kategoris = kategoriler;
            return View(yaziGüncellemeViewModel);

        }

       
        
        
        [HttpGet]
        public async Task<IActionResult> YaziSil()
        {
            var yazilar = await yaziService.SilimisTümYaziVeKategorileriGetirAsync();

            return View(yazilar);
        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid yaziId)
        {
            var baslik = await yaziService.YaziGüvenliSilmeAsync(yaziId);
            notification.AddErrorToastMessage(Messages.Yazi.Sil(baslik), new ToastrOptions { Title = "İşlem Başarılı!" });


            return RedirectToAction("Index", "Yazi", new { Area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> GeriSilme(Guid YaziId)
        {

            var baslik = await yaziService.YaziGüvenliGetirAsync(YaziId);
            notification.AddErrorToastMessage(Messages.Yazi.GeriSil(baslik), new ToastrOptions { Title = "Seni Yeniden aramızda Görmek Ne Güzel!" });


            return RedirectToAction("Index", "Yazi", new { Area = "Admin" });

        }


    }
}
