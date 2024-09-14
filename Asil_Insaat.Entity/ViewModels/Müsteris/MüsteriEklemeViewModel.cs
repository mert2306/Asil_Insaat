using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Müsteris
{
    public class MüsteriEklemeViewModel
    {
        public string Isim { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; } 
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }
        public string OdemeSarti { get; set; }
        //public bool Etkin { get; set; }
    }
}
