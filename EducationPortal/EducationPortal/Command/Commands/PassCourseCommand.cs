﻿using EducationPortal.Command.Interfaces;
using EducationPortal.Controllers;
using EducationPortal.Creator;
using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command.Commands
{
    public class PassCourseCommand : IAuthCommand
    {
        readonly static TestController testController = new TestController(CustomServiceProvider.Provider.GetRequiredService<ICourseTestService>());

        readonly UserConroller userController = new UserConroller(CustomServiceProvider.Provider.GetRequiredService<IUserService>(), testController);

        readonly static VideoMaterialController videoMaterialController = new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>());
        readonly static ArticleMaterialController articleMaterialController = new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>());
        readonly static BookMaterialController bookMaterialController = new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>());

        readonly CourseController courseController = new CourseController(CustomServiceProvider.Provider.GetRequiredService<ICourseService>(), videoMaterialController,articleMaterialController,bookMaterialController);
        public int CommandNumber => 2;

        public string CommandName => "Pass course";

        public void Execute()
        {
            Console.Clear();
            courseController.GetAllCourses();
            Console.Write("Enter course Id: ");
            var courseId = Int32.Parse(Console.ReadLine());
            var courseVM = courseController.GetCourseById(courseId);

            if (userController.AddCourseToUserProgress(courseVM))
            {
                courseController.GetCourseMaterials(courseVM);
                courseController.PassCourseMaterials();
                userController.UserPassCourse(courseVM);
            }
        }
    }
}
