﻿using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class TeklifValidator : AbstractValidator<Teklif>
    {

        public TeklifValidator()
        {
            RuleFor(a => a.Aciklama)
                .NotEmpty()
                .NotNull()
                .Length(3, 200)
                .WithName("Başlık");
            
        }
    }
}
