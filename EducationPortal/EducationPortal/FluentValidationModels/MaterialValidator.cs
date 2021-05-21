using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
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
