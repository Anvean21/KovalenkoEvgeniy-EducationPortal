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
    public class SkillValidator : AbstractValidator<SkillVM>
    {
        private static readonly ISkillService skillService = CustomServiceProvider.Provider.GetRequiredService<ISkillService>();
        public SkillValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 30).Must(UniqueSkill).WithMessage("Skill already exists");
            RuleFor(x => x.Level).NotNull();
        }
        private bool UniqueSkill(string uniqeItem)
        {
            if (skillService.GetUniqueName(uniqeItem))
            {
                return true;
            }
            return false;
        }
    }
}
