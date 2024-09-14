using Asil_Insaat.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Videos
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        public AppUser User { get; set; }
        public Resim Resim { get; set; }


        public string Olusturan { get; set; }
        public bool SilinmisMi { get; set; }

    }
}
