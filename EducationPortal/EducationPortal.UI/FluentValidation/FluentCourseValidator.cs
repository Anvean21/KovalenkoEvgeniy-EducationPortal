using EducationPortal.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentCourseValidator : AbstractValidator<CourseVM>
    {
        public FluentCourseValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course name already taken");
            RuleFor(x => x.Description).NotEmpty().Length(5, 300);
            //RuleForEach(x => x.Skills).NotEmpty().NotNull();
            //RuleForEach(x => x.Materials).NotEmpty().NotNull();
            //RuleFor(x => x.Test).NotEmpty().NotNull();
        }
    }
}
