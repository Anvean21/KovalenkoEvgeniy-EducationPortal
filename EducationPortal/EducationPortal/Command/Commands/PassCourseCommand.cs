using EducationPortal.Command.Interfaces;
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

        readonly UserConroller userController = new UserConroller(CustomServiceProvider.Provider.GetRequiredService<IUserService>(),
            new TestController(CustomServiceProvider.Provider.GetRequiredService<ITestService>()));

        readonly CourseController courseController = new CourseController(CustomServiceProvider.Provider.GetRequiredService<ICourseService>(),
            new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>()),
            new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>()),
            new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>()));
        public int CommandNumber => 2;

        public string CommandName => "Pass course";

        public void Execute()
        {
            Console.Clear();
            courseController.GetAllCourses();
            Console.Write("Enter course Id: ");
            var id = Int32.Parse(Console.ReadLine());
            var courseVM = courseController.GetCourseById(id);

            if (userController.AddCourseToUserProgress(courseVM))
            {
                courseController.GetCourseMaterials(courseVM);
                courseController.PassCourseMaterials();
                userController.UserPassCourse(courseVM);
            }
        }
    }
}
