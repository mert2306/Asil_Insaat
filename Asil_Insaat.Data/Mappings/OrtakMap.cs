﻿using Asil_Insaat.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Data.Mappings
{
    public class OrtakMap : IEntityTypeConfiguration<Ortak>
    {
        public void Configure(EntityTypeBuilder<Ortak> builder)
        {
            builder.HasData(new Ortak
            {
                Id = Guid.Parse("4A4F8575-FB28-4762-BB3E-BF3196B88EDB"),
                Baslik = "Images/testImages",
                Baglanti = "Referans",
                Oluşturan = "Mertcan asil",
                SilinmisMi = false,
                FileType = "jpg",
                ResimId = Guid.Parse("C70801CA-CC45-4079-83C6-B0DA466BBABB"),
                UserId = Guid.Parse("83314624-C7A0-4468-A6AA-1F2AF06F4660"),


            },
            new Ortak
            {
                Id = Guid.Parse("5CCC76F0-FB06-487F-9768-670C4E4A83F1"),
                Baslik = "Images/AsiltestImages",
                Baglanti = "Referans1",
                Oluşturan = "Vahit asil",
                FileType = "jpg",
                SilinmisMi = false,
                UserId = Guid.Parse("BEF76420-D441-4820-A5C0-5B39D62A8E0B"),
                ResimId = Guid.Parse("77E2D3F6-B7BF-4549-B7E2-7673D57586D6")
            });
        }
    }
}