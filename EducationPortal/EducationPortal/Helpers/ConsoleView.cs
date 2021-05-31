using EducationPortal.Controllers;
using EducationPortal.Creator;
using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EducationPortal.Helpers
{
    public class ConsoleView
    {
        
        readonly UserConroller userController = new UserConroller(CustomServiceProvider.Provider.GetRequiredService<IUserService>(), 
            new TestController(CustomServiceProvider.Provider.GetRequiredService<ITestService>()));

        readonly CourseController courseController = new CourseController(CustomServiceProvider.Provider.GetRequiredService<ICourseService>(), 
            new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>()), 
            new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>()),
            new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>()));

        public void ViewForUnautorizedUser()
        {
            Console.WriteLine("1 - Registration\n2 - Log In");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    userController.UserCreate();
                    break;
                case "2":
                    Console.Clear();
                    userController.UserLogIn();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public void ViewForAuthorizedUser()
        {
            Console.WriteLine("1 - Add course\n2 - Pass the course\n3 - LogOut");
            switch (Console.ReadLine())
            {
                case "1":
                    courseController.CourseCreate();
                    break;
                case "2":
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
                    break;
                case "3":
                    Console.Clear();
                    userController.UserLogOut();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
