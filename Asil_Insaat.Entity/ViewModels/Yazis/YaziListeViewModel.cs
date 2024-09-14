using Asil_Insaat.Entity.Entities;

namespace Asil_Insaat.Entity.ViewModels.Yazis
{
    public class YaziListeViewModel
    {


        public IList<Yazi> Yazis { get; set; }
        public Guid? KategoriId { get; set; }

        public Resim Resim { get; set; }

        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 3;
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false;
    }
}
