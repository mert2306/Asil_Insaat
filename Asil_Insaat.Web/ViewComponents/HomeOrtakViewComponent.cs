using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asil_Insaat.Web.ViewComponents
{
    public class HomeOrtakViewComponent : ViewComponent
    {
        private readonly IOrtakService ortakService;

        public HomeOrtakViewComponent(IOrtakService ortakService )
        {
            this.ortakService = ortakService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ortaks = await ortakService.SilinmemisOrtaklariGetirAsync();
            return View(ortaks);
        }

    }
}
