namespace Asil_Insaat.Core.Veris
{
    public class VeriTabani : IVeriTabani
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string Oluşturan { get; set; } = "Tanımsız";
        public virtual string? Düzenleyen { get; set; }
        public virtual DateTime OlusturulmaTarihi { get; set; } = DateTime.Now.Date;

        public virtual DateTime? DüzenlemeTarihi { get; set; }

        public virtual DateTime? SilmeTarihi { get; set; }

        public virtual string? Silen { get; set; }
        public virtual bool SilinmisMi { get; set; } = false;

    }
}
