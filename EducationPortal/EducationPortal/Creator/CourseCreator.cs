using AutoMapper;
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
using System.Linq;
using System.Text;

namespace EducationPortal.Creator
{
    public class CourseCreator
    {
        readonly ICourseService courseService;
        public CourseCreator(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        readonly CourseHelper courseHelper = new CourseHelper();

        readonly CourseValidator validator = new CourseValidator();

        public void CourseCreate()
        {
            var courseVM = courseHelper.CourseFullData();
            if (validator.Validate(courseVM).IsValid && courseVM.Skills.Count >= 1 && courseVM.Materials.Count >= 1)
            {
                courseService.AddCourse(Map.CourseVmToDomain(courseVM));
                Dye.Succsess();
                Console.WriteLine("You have successfully created course");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(courseVM));
                Console.WriteLine(new Exception("Course is not added, try again."));
                Console.ResetColor();
            }
        }
    }
}
