using EducationPortal.Automapper;
using EducationPortal.Controllers;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using EducationPortal.ViewModels.TestViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Creator
{
    public class CourseController
    {
        readonly ICourseService courseService;
        private readonly IMapper mapper;
        private readonly MaterialController materialController;

        readonly List<VideoMaterialVM> videoMaterials = new List<VideoMaterialVM>();
        readonly List<BookMaterialVM> bookMaterials = new List<BookMaterialVM>();
        readonly List<ArticleMaterialVM> articleMaterials = new List<ArticleMaterialVM>();

        readonly CourseHelper courseHelper = new CourseHelper();
        readonly MaterialHelper materialHelper = new MaterialHelper();

        readonly CourseValidator validator = new CourseValidator();

        public CourseController(ICourseService courseService, IMapper mapper, MaterialController materialController)
        {
            this.courseService = courseService;
            this.materialController = materialController;
            this.mapper = mapper;
        }

        public void CourseCreate()
        {
            var courseVM = courseHelper.CourseFullData();
            if (validator.Validate(courseVM).IsValid && courseVM.Skills.Count >= 1 && courseVM.Materials.Count >= 1)
            {
                var mappedCourse = mapper.Map<CourseVM, Course>(courseVM);
                courseService.AddCourse(mappedCourse);

                courseVM.Id = mappedCourse.Id;

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

        public void GetAllCourses()
        {
            foreach (var course in courseService.GetCourses())
            {
                Console.WriteLine($"Course Id - {course.Id}, Course name - {course.Name}, Course description - {course.Description}, Skills - {string.Join(", ", course.Skills.Select(x => x.Name))}");
            }
        }

        public CourseVM GetCourseById(int id)
        {
            var course = courseService.GetById(id);
            var mappedCourse = mapper.Map<Course, CourseVM>(course);
            return mappedCourse;
        }

        public void GetCourseMaterials(CourseVM courseVM)
        {
            var course = GetCourseById(courseVM.Id);

            foreach (var material in course.Materials)
            {
                var materialVM = materialController.AddMaterialById(material.Id);

                if (materialVM is VideoMaterialVM videoMaterial)
                {
                    videoMaterials.Add(videoMaterial);
                }
                if (materialVM is BookMaterialVM bookMaterial)
                {
                    bookMaterials.Add(bookMaterial);
                }
                if (materialVM is ArticleMaterialVM articleMaterial)
                {
                    articleMaterials.Add(articleMaterial);
                }
            }
        }

        public void PassCourseMaterials()
        {
            var infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - videos\t2 - books\t3 - articles\t4 - pass course test\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        materialHelper.VideoMaterials(videoMaterials);
                        break;
                    case "2":
                        Console.Clear();
                        materialHelper.BookMaterials(bookMaterials);
                        break;
                    case "3":
                        Console.Clear();
                        materialHelper.ArticleMaterials(articleMaterials);
                        break;
                    case "4":
                        infinity = false;
                        break;
                    default:
                        Console.Clear();
                        continue;
                }
            }
        }
    }
}
