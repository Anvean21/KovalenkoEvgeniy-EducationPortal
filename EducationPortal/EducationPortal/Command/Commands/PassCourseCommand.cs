using EducationPortal.Automapper;
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
        readonly static TestController testController = new TestController(CustomServiceProvider.Provider.GetRequiredService<ICourseTestService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly UserConroller userController = new UserConroller(CustomServiceProvider.Provider.GetRequiredService<IUserService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>(), testController);

        readonly static VideoMaterialController videoMaterialController = new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());
        readonly static ArticleMaterialController articleMaterialController = new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());
        readonly static BookMaterialController bookMaterialController = new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly CourseController courseController = new CourseController(CustomServiceProvider.Provider.GetRequiredService<ICourseService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>(), videoMaterialController,articleMaterialController,bookMaterialController);
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
