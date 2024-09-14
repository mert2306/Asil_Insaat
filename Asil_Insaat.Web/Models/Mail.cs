using System.ComponentModel.DataAnnotations;

namespace Asil_Insaat.Web.Models
{
    public class Mail
    {
        [Required]
        public string AdiSoyadi { get; set; }
        
        [Required]
        public string Email { get; set; }
        [Required]
        public string Konu { get; set; }
        [Required]
        public string Mesaj { get; set; }
    }
}
