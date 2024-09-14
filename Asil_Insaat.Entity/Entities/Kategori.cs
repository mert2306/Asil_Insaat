using Asil_Insaat.Core.Veris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.Entities
{
    public class Kategori : VeriTabani
    {
        private string ısim;

        public Kategori()
        {
        }

        public Kategori(string ısim)
        {
            this.ısim = ısim;
        }

        public Kategori(string isim, string olusturan)
        {
            Isim = isim;
            Oluşturan = olusturan;
        }

        public string Isim { get; set; }

        public ICollection<Yazi> Yazis { get; set; }


    }
}
