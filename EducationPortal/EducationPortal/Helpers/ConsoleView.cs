using EducationPortal.Automapper;
using EducationPortal.Creator;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Helpers
{
    public class ConsoleView
    {
        readonly UserCreator UserCreator = new UserCreator(CustomServiceProvider.Provider.GetRequiredService<IUserService>());

        readonly CourseCreator CourseCreator = new CourseCreator(CustomServiceProvider.Provider.GetRequiredService<ICourseService>());

        public void ViewForUnautorizedUser()
        {
            Console.WriteLine("1 - Registration\n2 - Log In");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    UserCreator.UserCreate();
                    break;
                case "2":
                    Console.Clear();
                    UserCreator.UserLogIn();
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
                    CourseCreator.CourseCreate();
                    break;
                case "2":

                    break;
                case "3":
                    Console.Clear();
                    UserCreator.UserLogOut();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
