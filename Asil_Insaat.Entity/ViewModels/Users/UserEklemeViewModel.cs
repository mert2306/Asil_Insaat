using Asil_Insaat.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Entity.ViewModels.Users
{
    public class UserEklemeViewModel
    {
        public Guid RoleId { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }

        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Parola { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}
