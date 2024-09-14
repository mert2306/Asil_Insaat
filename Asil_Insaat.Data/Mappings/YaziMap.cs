using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Asil_Insaat.Entity.Entities;

namespace Asil_Insaat.Data.Mappings
{
    public class YaziMap : IEntityTypeConfiguration<Yazi>
    {
        public void Configure(EntityTypeBuilder<Yazi> builder)
        {
            builder.HasData(new Yazi
            {
                Id = Guid.NewGuid(),
                Baslik = "Mertcan",
                Icerik = "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                KategoriId = Guid.Parse("9F8CAD02-C349-423E-B688-688CDA3F65F8"),
                ResimId = Guid.Parse("C70801CA-CC45-4079-83C6-B0DA466BBABB"),
                UserId = Guid.Parse("83314624-C7A0-4468-A6AA-1F2AF06F4660"),
                Oluşturan = "Mertcan Asil",
                Fiyat = "0",
                Bilgi1 = "0",
                Bilgi2 = "0",
                Bilgi3 = "0",
                Bilgi4 = "0",
                Bilgi5 = "0",
                Bilgiİcerik1 = "Bilgi",
                Bilgiİcerik2 = "Bigi",
                Bilgiİcerik3 = "Bilgi",
                Bilgiİcerik4 = "Bilgi",
                Bilgiİcerik5 = "Bilgi",
                OlusturulmaTarihi = DateTime.Now,
                SilinmisMi = false,
                Dosya = "link"
            },
            new Yazi
            {
                Id = Guid.NewGuid(),
                Baslik = "Mertcan",
                Icerik = "Mertcan Deneme Makalesi Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                KategoriId = Guid.Parse("B8A1C719-2D28-403B-B503-54497205ED6B"),
                ResimId = Guid.Parse("77E2D3F6-B7BF-4549-B7E2-7673D57586D6"),
                UserId = Guid.Parse("BEF76420-D441-4820-A5C0-5B39D62A8E0B"),
                Oluşturan = "Vahit asil",
                Fiyat = "0",
                Bilgi1 = "0",
                Bilgi2 = "0",
                Bilgi3 = "0",
                Bilgi4 = "0",
                Bilgi5 = "0",
                Bilgiİcerik1 = "Bilgi",
                Bilgiİcerik2 = "Bigi",
                Bilgiİcerik3 = "Bilgi",
                Bilgiİcerik4 = "Bilgi",
                Bilgiİcerik5 = "Bilgi",
                OlusturulmaTarihi = DateTime.Now,
                SilinmisMi = false,
                Dosya = "link"
            });
        }
    }
}
