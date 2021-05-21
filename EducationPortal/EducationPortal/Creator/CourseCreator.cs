using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Creator
{
    public class CourseCreator
    {
        private static readonly ICourseService courseService = CustomServiceProvider.Provider.GetRequiredService<ICourseService>();
        static CourseValidator validator = new CourseValidator();
        public static void CourseCreate()
        {
            var courseVM = CourseHelper.CourseFullData();
            if (validator.Validate(courseVM).IsValid)
            {
                courseService.AddCourse(Map.MapVmToDomain<CourseVM, Course>(courseVM));
                Console.Clear();
                Console.WriteLine("You have successfully added course");
            }
            else
            {
                validator.ValidateAndThrow(courseVM);
            }
        }
    }
}
