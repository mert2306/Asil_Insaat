using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Ortaks
{
    public class OrtakEklemeViewModel
    {
        public string? Baslik { get; set; }
        public string? Baglanti { get; set; }
        public string? fileType { get; set; }

        public IFormFile Ortak { get; set; }
    }
}
