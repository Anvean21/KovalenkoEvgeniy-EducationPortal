using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class ArticleMaterialValidator : AbstractValidator<ArticleMaterialVM>
    {
        public ArticleMaterialValidator()
        {
            RuleFor(x => x.Resource).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty().Must(x => x.Date <= DateTime.Today);
        }
    }
}
