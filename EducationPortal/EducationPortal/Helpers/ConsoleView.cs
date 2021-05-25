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
        readonly UserCreator userCreator = new UserCreator(CustomServiceProvider.Provider.GetRequiredService<IUserService>());

        readonly CourseCreator courseCreator = new CourseCreator(CustomServiceProvider.Provider.GetRequiredService<ICourseService>());

        public void ViewForUnautorizedUser()
        {
            Console.WriteLine("1 - Registration\n2 - Log In");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    userCreator.UserCreate();
                    break;
                case "2":
                    Console.Clear();
                    userCreator.UserLogIn();
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
                    courseCreator.CourseCreate();
                    break;
                case "2":

                    break;
                case "3":
                    Console.Clear();
                    userCreator.UserLogOut();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
