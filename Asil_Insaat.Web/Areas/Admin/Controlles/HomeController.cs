using Asil_Insaat.Service.Service.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.Areas.Admin.Controlles
{
    [Area("Admin")]
    [Authorize]

    public class HomeController : Controller
    {
        private readonly IYaziService yaziService;

        public HomeController(IYaziService yaziService)
        {
            this.yaziService = yaziService;
        }

        public async Task<IActionResult> Index()
        {
            var yazilar = await yaziService.SilinmemisTümYaziVeKategorileriGetirAsync();
            return View(yazilar);
        }





    }
}
