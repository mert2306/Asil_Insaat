using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class KategoriValidator : AbstractValidator<Kategori>

    {
        public KategoriValidator()
        {
            RuleFor(a => a.Isim)
                .NotEmpty()
                .NotNull()
                .Length(3, 200)
                .WithName("Kategori İsmi");
        }
    }
}
