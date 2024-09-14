using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class SatisBirimiValidator : AbstractValidator<SatisBirimi>
    {
        public SatisBirimiValidator()
        {
            RuleFor(a => a.Aciklama)
                
                .Length(1, 200)
                .WithName("Satış Birimi A.ıklma");
        }
    }
}
