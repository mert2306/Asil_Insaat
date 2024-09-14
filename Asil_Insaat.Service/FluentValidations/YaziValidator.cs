using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class YaziValidator : AbstractValidator<Yazi>
    {
        public YaziValidator()
        {
            RuleFor(a => a.Baslik)
                .NotEmpty()
                .NotNull()
                .Length(3, 200)
                .WithName("Başlık");
            RuleFor(a => a.Icerik)
                .NotEmpty()
                .NotNull()
                .Length(3, 10000000)
                .WithName("İçerik");

        }



    }
}
