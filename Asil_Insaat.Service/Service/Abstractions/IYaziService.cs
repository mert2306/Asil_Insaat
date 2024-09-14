using Asil_Insaat.Entity.Entities;
using Asil_Insaat.Entity.ViewModels.Yazis;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IYaziService
    {
        Task<List<YaziViewModel>> SilinmemisTümYaziVeKategorileriGetirAsync();
        Task<List<YaziViewModel>> SilimisTümYaziVeKategorileriGetirAsync();

        Task YaziOlusturAsync(YaziEklemeViewModel yaziEklemeViewModel);
        Task<YaziViewModel> SilinmemisYaziVeKategorileriGetirAsync(string baslik);
        Task<string> YaziGüncelleAsync(YaziGüncellemeViewModel yaziGüncellemeViewModel);

        Task<string> YaziGüvenliSilmeAsync(Guid yaziId);
        Task<string> YaziGüvenliGetirAsync(Guid yaziId);
        Task<List<Yazi>> TümYazilarıGetirAsync();
        Task<YaziListeViewModel> SayfaYazilariniGetirAsync(Guid kategoriId, int currentPage = 1, int pageSize = 3, bool isAscending = false);

        Task<YaziListeViewModel> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);

        Task<bool> BaslikBenzersizMiAsync(string baslik);







    }
}
