using Asil_Insaat.Core.Veris;
using Microsoft.AspNetCore.Identity;

namespace Asil_Insaat.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IVeriTabani
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public Guid ResimId { get; set; } = Guid.Parse("AAEF23AA-4F75-453A-8848-AEBC714021DC");
        public Resim Resim { get; set; }


        public ICollection<Yazi> Yazis { get; set; }

        public ICollection<Teklif> Teklifs { get; set; }
    }
}
