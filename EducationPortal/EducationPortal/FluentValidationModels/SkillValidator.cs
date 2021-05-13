using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
   public class SkillValidator : AbstractValidator<SkillVM>
    {
        public SkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Invalid name");
            RuleFor(x => x.Level).NotEmpty();
        }
    }
}
