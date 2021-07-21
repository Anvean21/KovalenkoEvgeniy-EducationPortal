using EducationPortal.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentBookMaterialValidator : AbstractValidator<BookMaterialVM>
    {
        public FluentBookMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 128);
            RuleFor(x => x.Author).NotEmpty().Length(2, 128);
            RuleFor(x => x.Pages).NotEmpty();
            RuleFor(x => x.YearOfPublish).NotEmpty().Must(x => x <= DateTime.Today.Year);
        }
    }
}
