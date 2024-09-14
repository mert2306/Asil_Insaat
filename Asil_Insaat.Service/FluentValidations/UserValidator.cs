using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {

        public UserValidator()
        {
            RuleFor(x => x.Isim)
            .NotEmpty()
            .Length(1, 50)
            .WithName("İsim");
            RuleFor(x => x.Soyisim)
             .NotEmpty()
             .Length(1, 50)
             .WithName("Soyisim");
            



        }
    }
}
