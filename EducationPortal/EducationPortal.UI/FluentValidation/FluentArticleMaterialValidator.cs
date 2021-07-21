using EducationPortal.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentArticleMaterialValidator : AbstractValidator<ArticleMaterialVM>
    {
        public FluentArticleMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 128);
            RuleFor(x => x.Resource).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty().Must(x => x.Date <= DateTime.Today);
        }
    }
}
