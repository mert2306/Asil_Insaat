namespace Asil_Insaat.Web.DonutMesajlari
{
    public static class Messages
    {
        public static class Yazi
        {

            public static string Ekle(string YaziBaslık)
            {
                return $"{YaziBaslık} başlıklı Makale Başarılı Bir Şekilde Eklendi!";
            }
            public static string Güncelle(string yaziBaslik)
            {
                return $"{yaziBaslik} başlıklı Makale Başarılı Bir Şekilde Güncellendi!";
            }
            public static string Sil(string yaziBaslik)
            {
                return $"{yaziBaslik} başlıklı Makale Başarılı Bir Şekilde Silindi!";
            }
            public static string GeriSil(string yaziBaslik)
            {
                return $"{yaziBaslik} başlıklı Makale Başarılı Bir Şekilde Geri Getirildi!";
            }
        }

        public static class Kategori
        {
            public static string Ekle(string KategoriIsim)
            {
                return $"{KategoriIsim} başlıklı kategori Başarılı Bir Şekilde Eklendi!";
            }
            public static string Güncelle(string KategoriIsim)
            {
                return $"{KategoriIsim} başlıklı kategori Başarılı Bir Şekilde Güncellendi!";
            }
            public static string Sil(string KategoriIsim)
            {
                return $"{KategoriIsim} başlıklı kategori Başarılı Bir Şekilde Silindi!";
            }
            public static string GüvenliSil(string KategoriIsim)
            {
                return $"{KategoriIsim} başlıklı Kategori Başarılı Bir Şekilde Geri Getirildi!";
            }
        }
   
    }
    public static class User
    {
        public static string Ekle(string userIsim)
        {
            return $"{userIsim}  İsimli Kullanıcı Başarılı Bir Şekilde Eklendi!";
        }
        public static string Güncelle(string userIsim)
        {
            return $"{userIsim} İsimli Kullanıcı Başarılı Bir Şekilde Güncellendi!";
        }
        public static string Sil(string userIsim)
        {
            return $"{userIsim} İsimli Kullanıcı Başarılı Bir Şekilde Silindi!";
        }
    }
}
