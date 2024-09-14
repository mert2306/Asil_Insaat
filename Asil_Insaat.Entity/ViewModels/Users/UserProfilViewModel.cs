using Asil_Insaat.Entity.Entities;
using Microsoft.AspNetCore.Http;

namespace Asil_Insaat.Entity.ViewModels.Users
{
    public class UserProfilViewModel
    {
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string GecerliParola { get; set; }
        public string? YeniParola { get; set; }
        public IFormFile? Fotograf { get; set; }
        public Resim Resim { get; set; }
    }
}
