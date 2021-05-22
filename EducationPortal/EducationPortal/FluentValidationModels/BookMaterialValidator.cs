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
    public class BookMaterialValidator : AbstractValidator<BookMaterialVM>
    {

        private static readonly IMaterialService materialService = CustomServiceProvider.Provider.GetRequiredService<IMaterialService>();
        public BookMaterialValidator()
        {
            RuleFor(x => x.Author).NotEmpty().Must(UniqueMaterial).WithMessage("Book name already taken");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Pages).NotEmpty();
            RuleFor(x => x.Passed).NotNull();
            RuleFor(x => x.YearOfPublish).NotEmpty().Must(x => x <= DateTime.Today.Year);
        }
        private bool UniqueMaterial(string uniqeItem)
        {
            if (materialService.GetBookMaterials().Any(x => x.Name.ToLower() == uniqeItem.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}
