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

        private static readonly IMaterialService materialService = CustomServiceProvider.Provider.GetRequiredService<IMaterialService>();
        public ArticleMaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(UniqueMaterial).WithMessage("Article name already taken");
            RuleFor(x => x.Passed).NotNull();
            RuleFor(x => x.Resource).NotEmpty();
            RuleFor(x => x.PublishDate).NotEmpty().Must(x => x.Date <= DateTime.Today);
        }
        private bool UniqueMaterial(string uniqeItem)
        {
            if (materialService.GetArticleMaterials().Any(x => x.Name.ToLower() == uniqeItem.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
