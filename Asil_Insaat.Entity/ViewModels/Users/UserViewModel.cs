using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }

        public string Email { get; set; }
        public string Telefon { get; set; }
        public bool EmailDogrulama { get; set; }

        public string Role { get; set; }
    }
}
