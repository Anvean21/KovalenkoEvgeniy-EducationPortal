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
    public class AddCourseCommand : IAuthCommand
    {

        readonly CourseController courseController = new CourseController(
            CustomServiceProvider.Provider.GetRequiredService<ICourseService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>(),

            new MaterialController(
                 CustomServiceProvider.Provider.GetRequiredService<IMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>()));
        public int CommandNumber => 1;

        public string CommandName => "Create course";

        public void Execute()
        {
            Console.Clear();
            courseController.CourseCreate();
        }
    }
}
