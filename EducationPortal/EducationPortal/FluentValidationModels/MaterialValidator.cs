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
        public MaterialValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Passed).NotNull();
        }
    }
}
