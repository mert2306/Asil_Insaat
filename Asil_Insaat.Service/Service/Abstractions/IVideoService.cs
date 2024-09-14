using Asil_Insaat.Entity.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.Service.Abstractions
{
    public interface IVideoService
    {
        Task<List<VideoViewModel>> SilinmemisVideolariGetirAsync();
        Task VideoOlusturAsync(VideoEklemeViewModel videoEklemeViewModel);
        Task<string> VideoGüncelleAsync(VideoGüncellemeViewModel videoGüncellemeViewModel);
        Task<VideoViewModel> SilinmemisVideolariGetirIdGöreAsync(Guid videoId);
        Task<string> VideoGüvenliSilmeAsync(Guid videoId);
        Task<List<VideoViewModel>> SilimisTümVideolariGetirAsync();
        Task<string> VideoGüvenliGetirAsync(Guid videoId);

    }
}
