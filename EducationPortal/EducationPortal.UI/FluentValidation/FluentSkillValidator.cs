using EducationPortal.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentSkillValidator : AbstractValidator<SkillVM>
    {
        public FluentSkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 30).WithMessage("Skill already exists");
            RuleFor(x => x.Level).NotNull();
        }
    }
}
