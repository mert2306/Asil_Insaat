using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asil_Insaat.Data.Mappings
{
    public class KategoriMap : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(
               new Kategori
               {
                   Id = Guid.Parse("9F8CAD02-C349-423E-B688-688CDA3F65F8"),
                   Isim = "Birinci",
                   Oluşturan = "Mertcan Asil",
                   OlusturulmaTarihi = DateTime.Now,
                   SilinmisMi = false,
               },
              new Kategori
              {
                  Id = Guid.Parse("B8A1C719-2D28-403B-B503-54497205ED6B"),
                  Isim = "Ikinci",
                  Oluşturan = "Vahit Asil",
                  OlusturulmaTarihi = DateTime.Now,
                  SilinmisMi = false,
              });
        }

    }
}
