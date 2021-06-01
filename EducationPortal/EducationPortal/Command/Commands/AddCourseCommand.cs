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
    public class AddCourseCommand : IAuthCommand
    {
        readonly CourseController courseController = new CourseController(CustomServiceProvider.Provider.GetRequiredService<ICourseService>(),
            new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>()),
            new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>()),
            new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>()));
        public int CommandNumber => 1;

        public string CommandName => "Create course";

        public void Execute()
        {
            courseController.CourseCreate();
        }
    }
}
