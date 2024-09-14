using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asil_Insaat.Data.Mappings
{
    public class ResimMap : IEntityTypeConfiguration<Resim>
    {
        public void Configure(EntityTypeBuilder<Resim> builder)
        {
            builder.HasData(new Resim
            {
                Id = Guid.Parse("C70801CA-CC45-4079-83C6-B0DA466BBABB"),
                FileName = "Images/testImages",
                FileType = "jpg",
                Oluşturan = "Mertcan asil",
                SilinmisMi = false

            },
            new Resim
            {
                Id = Guid.Parse("77E2D3F6-B7BF-4549-B7E2-7673D57586D6"),
                FileName = "Images/AsiltestImages",
                FileType = "png",
                Oluşturan = "Vahit asil",
                SilinmisMi = false,

            }
             
            );
        }
    }
}
