using Asil_Insaat.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Ortaks
{
    public class OrtakViewModel
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string Baglanti { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public AppUser User { get; set; }
        public Resim Resim { get; set; }


        public string Olusturan { get; set; }
        public bool SilinmisMi { get; set; }
    }
}
