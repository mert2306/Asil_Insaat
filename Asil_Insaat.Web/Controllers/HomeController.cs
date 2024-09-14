using Asil_Insaat.Service.Service.Abstractions;
using Asil_Insaat.Service.Service.Concrete;
using Asil_Insaat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Asil_Insaat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IYaziService yaziService;
        private readonly IFotografService fotografService;
        private readonly IVideoService videoService;
        private readonly IGaleriService galeriService;
        private readonly IOrtakService ortakService;

        public HomeController(ILogger<HomeController> logger, IYaziService yaziService, IFotografService fotografService, IVideoService videoService, IGaleriService galeriService, IOrtakService ortakService)
        {
            _logger = logger;
            this.yaziService = yaziService;
            this.fotografService = fotografService;
            this.videoService = videoService;
            this.galeriService = galeriService;
            this.ortakService = ortakService;
        }

        public IActionResult Index()
        {
        
            return View();

        }
        public async Task<IActionResult> CalismaAlanlarimiz()
        {
            var yazis = await yaziService.SilinmemisTümYaziVeKategorileriGetirAsync();
           
            return View(yazis);
        }
        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult TerasYalitimi()
        {
            return View();
        }
        public IActionResult ZeminYalitimi()
        {
            return View();
        }
        public IActionResult SuDeposuYalitimi()
        {
            return View();
        }
        public IActionResult HavuzYalitimi()
        {
            return View();
        }

        public async Task<IActionResult> Belgelerimiz()
        {
            var yazis = await yaziService.TümYazilarıGetirAsync();
            return View(yazis);
        }

        public async Task <IActionResult> Video()
        {
            var video = await videoService.SilinmemisVideolariGetirAsync();
            return View(video);
        }
        public async Task<IActionResult> Incele(string baslik)
        {
            var yazi = await yaziService.SilinmemisYaziVeKategorileriGetirAsync(baslik);
            return View(yazi);

        }
        public async Task<IActionResult> Referans()
        {
            var fotografs = await fotografService.SilinmemisFotograflariiGetirAsync();

            return View(fotografs);
        }
        public  IActionResult Iletisim()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Iletisim(Mail m)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); 
                client.Credentials = new NetworkCredential("asilinsaatyapiyalitim@gmail.com", "mevo ozyb nael ximr");
                client.EnableSsl = true;
                MailMessage msj = new MailMessage(); 
                msj.From = new MailAddress(m.Email, m.AdiSoyadi); 
                msj.To.Add("asilinsaatyapiyalitim@gmail.com"); 
                msj.Subject = m.Konu + " " + m.Email; 
                msj.Body = m.Mesaj; 
                client.Send(msj); 
                MailMessage msj1 = new MailMessage();
                msj1.From = new MailAddress("asilinsaatyapiyalitim@gmail.com", "Asil İnşaat Yapı & Yalıtım");
                msj1.To.Add(m.Email); 
                msj1.Subject = "Mesaj Talebiniz";
                msj1.Body = "Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz! Size En kısa zamanda Döneceğiz." +
                    "" +
                    " Sayfamızda https://asilinsaatyapiyalitim.com.tr/ Bize Ulaşın Kısında Yer Alan 0(532) 225 12 49 Cep Telefonu Aracılığıyla Bize Daha Kısa Sürede Ulaşabilirsiniz. ";
                client.Send(msj1);
                ViewBag.Succes = "Teşekkürler Mailniz başarı bir şekilde gönderildi"; 
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Mesaj Gönderilken hata oluştu";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task< IActionResult> FotografGaleri()
        {
            var galeri = await galeriService.SilinmemisGaleriGetirAsync();
            return View(galeri);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await yaziService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(articles);
        }
    }
}