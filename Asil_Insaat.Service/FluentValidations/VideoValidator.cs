using Asil_Insaat.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asil_Insaat.Service.FluentValidations
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator() 
        {
            RuleFor(a => a.Baslik)
             .NotEmpty()
             .NotNull()
             .Length(3, 200)
             .WithName("Başlık");
            RuleFor(a => a.İcerik)
                .NotEmpty()
                .NotNull()
                .Length(3, 10000000)
                .WithName("İçerik");
        }
    }
}
