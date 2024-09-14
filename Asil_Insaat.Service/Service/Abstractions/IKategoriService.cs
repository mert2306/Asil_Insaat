using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Kategoris;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IKategoriService
    {
        Task<Kategori> KategoriGetirByGuid(Guid id);

        Task KategoriOlusturAsync(KategoriEklemeViewModel kategoriEklemeViewModel);

        Task<List<KategoriViewModel>> SilinmemisTümKategorileriGetir();

        Task<List<KategoriViewModel>> SilinmemisTümKategorileriGetirSıralı();
        Task<string> KategoriGüncelleAsync(KategoriGüncellemeViewModel kategoriGüncellemeViewModel);

        Task<List<KategoriViewModel>> TümSilinmisKAtegorileriGetir();
        Task<string> KategorileriGüvenliSilAsync(Guid kategoriId);

        Task<string> SilinenKategoriGeriGetirAsync(Guid kategoriId);






    }
}
