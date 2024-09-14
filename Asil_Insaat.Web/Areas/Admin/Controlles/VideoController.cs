using Asil_Insaat.Data.Mappings;
using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Fotograf;
using Asil_Insaat.Entity.ViewModels.Videos;
using Asil_Insaat.Service.Extensions;
using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]

    public class VideoController : Controller
    {
        private readonly IVideoService videoService;
        private readonly IMapper mapper;
        private readonly IValidator<Video> validator;

        public VideoController(IVideoService videoService, IMapper mapper, IValidator<Video> validator)
        {
            this.videoService = videoService;
            this.mapper = mapper;
            this.validator = validator;
        }



        public async Task <IActionResult> Index()
        {
            var video = await videoService.SilinmemisVideolariGetirAsync();

            return View(video);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(VideoEklemeViewModel videoEklemeViewModel)
        {

            var map = mapper.Map<Video>(videoEklemeViewModel);

            var result = await validator.ValidateAsync(map);



            await videoService.VideoOlusturAsync(videoEklemeViewModel);
            return RedirectToAction("Index", "Video", new { Area = "Admin" });



        }

        [HttpGet]
        public async Task<IActionResult> Güncelle(Guid videoId)
        {
            var video = await videoService.SilinmemisVideolariGetirIdGöreAsync(videoId);

            var videoGuncellemeViewModel = mapper.Map<VideoGüncellemeViewModel>(video);

            return View(videoGuncellemeViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Güncelle(VideoGüncellemeViewModel videoGüncellemeViewModel)
        {

            var map = mapper.Map<Video>(videoGüncellemeViewModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {

                var baslik = await videoService.VideoGüncelleAsync(videoGüncellemeViewModel);
                return RedirectToAction("Index", "Video", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            return View(videoGüncellemeViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid videoId)
        {
            var baslik = await videoService.VideoGüvenliSilmeAsync(videoId);


            return RedirectToAction("Index", "Video", new { Area = "Admin" });
        }


        [HttpGet]
        public async Task<IActionResult> VideoSil()
        {
            var videolar = await videoService.SilimisTümVideolariGetirAsync();

            return View(videolar);
        }

        [HttpGet]
        public async Task<IActionResult> GeriSilme(Guid videoId)
        {

            var baslik = await videoService.VideoGüvenliGetirAsync(videoId);


            return RedirectToAction("Index", "Video", new { Area = "Admin" });

        }
    }
}
