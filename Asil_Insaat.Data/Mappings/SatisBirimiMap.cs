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
    public class SatisBirimiMap : IEntityTypeConfiguration<SatisBirimi>

    {
        public void Configure(EntityTypeBuilder<SatisBirimi> builder)
        {
            builder.HasData(
               new SatisBirimi
               {
                
                    Id= Guid.NewGuid(),
                    Aciklama= "deneme"


               });


        }



    }
}


