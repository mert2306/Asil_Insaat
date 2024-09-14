using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Data.Mappings
{
    public class MüsteriMap : IEntityTypeConfiguration<Müsteri>
    {
        public void Configure(EntityTypeBuilder<Müsteri> builder)
        {
            builder.HasData(new Müsteri
            {
                Id = Guid.NewGuid(),
                Isim= "mertcan",
                Email = "mertcanasil3@gmail.com",
                OdemeSarti = "yarı peşin",
                Adres = "ev",
                Sehir = "elazığ",
                PostaKodu = "23100",
                Olusturan = "mertcan",

                Telefon="1111111"
                //Etkin = false



            });


        }
    }

}
