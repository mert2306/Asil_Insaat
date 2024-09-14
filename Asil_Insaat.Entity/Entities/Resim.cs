using Asil_Insaat.Core.Veris;

namespace Asil_Insaat.Entity.Entities
{
    public class Resim : VeriTabani
    {
        public Resim()
        {
            Users = new HashSet<AppUser>();
        }
        public Resim(string fileName, string fileType, string olusturan)
        {
            FileName = fileName;
            FileType = fileType;
            Oluşturan = olusturan;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Yazi> Yazis { get; set; }
        public ICollection<Fotograf> Fotografs { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Galeri> Galeris { get; set; }
        public ICollection<Ortak> Ortaks { get; set; }


    }
}
