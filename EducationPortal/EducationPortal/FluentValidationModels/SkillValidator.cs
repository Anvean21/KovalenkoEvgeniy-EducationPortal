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
            RuleFor(x => x.Name).NotEmpty().Length(2,30);
            RuleFor(x => x.Level).NotEmpty();
        }
    }
}
