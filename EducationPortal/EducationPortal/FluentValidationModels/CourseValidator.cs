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
    public class CourseValidator : AbstractValidator<CourseVM>
    {
        private static readonly ICourseService courseService = CustomServiceProvider.Provider.GetRequiredService<ICourseService>();
        public CourseValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(UniqueCourse).WithMessage("Course name already taken");
            RuleFor(x => x.Description).NotEmpty().Length(5, 300);
            RuleForEach(x => x.Skills).NotEmpty().NotNull();
            RuleForEach(x => x.Materials).NotEmpty().NotNull();
            RuleFor(x => x.Test).NotEmpty().NotNull();
        }

        private bool UniqueCourse(string uniqeItem)
        {
            if (courseService.UniqueCourseName(uniqeItem))
            {
                return true;
            }
            return false;
        }
    }
}
