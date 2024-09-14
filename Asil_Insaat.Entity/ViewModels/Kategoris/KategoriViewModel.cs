using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Kategoris
{
    public class KategoriViewModel
    {
        public Guid Id { get; set; }
        public string Isim { get; set; }
        public string Olusturan { get; set; }

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;


        public bool SilinmisMi { get; set; }
    }
}
