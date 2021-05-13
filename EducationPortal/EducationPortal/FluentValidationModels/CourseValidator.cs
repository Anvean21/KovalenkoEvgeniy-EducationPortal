using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
   public class CourseValidator: AbstractValidator<CourseVM>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(20).WithMessage("Invalid description. min 20 symbols");
            RuleForEach(x => x.Skills).SetValidator(new SkillValidator());
            RuleForEach(x => x.Materials).SetValidator(new MaterialValidator());
        }
    }
}
