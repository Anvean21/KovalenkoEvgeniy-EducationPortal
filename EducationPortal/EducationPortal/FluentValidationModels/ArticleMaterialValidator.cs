using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class ArticleMaterialValidator : AbstractValidator<ArticleMaterialVM>
    {
        public ArticleMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Passed).NotNull();
            RuleFor(x => x.Resource).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty().Must(x => x.Date <= DateTime.Today);
        }
    }
}
