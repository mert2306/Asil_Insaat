using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Müsteris
{
    public class MüsteriViewModel
    {
        public Guid Id { get; set; }

        public string Isim { get; set; }
        public string Email { get; set; }
        public string OdemeSarti { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }
        //public bool Etkin { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public bool SilinmisMi { get; set; }
    }
}
