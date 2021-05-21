using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class CourseValidator : AbstractValidator<CourseVM>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().Length(5, 300);
            RuleForEach(x => x.Skills).SetValidator(new SkillValidator());
            RuleForEach(x => x.Materials).SetValidator(new MaterialValidator());
        }
    }
}
