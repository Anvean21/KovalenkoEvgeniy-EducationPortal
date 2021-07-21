using EducationPortal.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentVideoMaterialValidator : AbstractValidator<VideoMaterialVM>
    {
        public FluentVideoMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2,128);
            RuleFor(x => x.Quality).NotNull();
            RuleFor(x => x.Duration).NotEmpty();
            RuleFor(x => x.Link).NotEmpty();
        }
    }
}
