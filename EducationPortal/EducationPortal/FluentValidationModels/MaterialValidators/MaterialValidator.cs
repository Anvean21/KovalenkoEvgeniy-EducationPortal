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
    public class MaterialValidator : AbstractValidator<MaterialVM>
    {
        private static readonly IMaterialService materialService = CustomServiceProvider.Provider.GetRequiredService<IMaterialService>();
        public MaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(UniqueMaterial).WithMessage("Material name already taken");
        }
        private bool UniqueMaterial(string uniqeItem)
        {
            if (materialService.UniqueMaterialName(uniqeItem))
            {
                return true;
            }
            return false;
        }
    }
}
