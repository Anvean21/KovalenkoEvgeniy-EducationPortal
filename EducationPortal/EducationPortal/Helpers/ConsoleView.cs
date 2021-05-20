using EducationPortal.Automapper;
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
    public static class ConsoleView
    {
        private static readonly IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();
        static UserValidator validator = new UserValidator();

        public static void ViewForUnautorizedUser()
        {
            Console.WriteLine("1 - Registration\n2 - Log In");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    var userVM = UserHelper.UserFullData();
                    if (validator.Validate(userVM).IsValid)
                    {
                        userService.Register(Map.MapVmToDomain<UserVM, User>(userVM));
                        Console.Clear();
                        Console.WriteLine("You have successfully registered and authorized");
                    }
                    else
                    {
                        validator.ValidateAndThrow(userVM);
                    }
                    break;
                case "2":
                    Console.Clear();
                    var turple = UserHelper.UserLoginData();

                    if (userService.LogIn(turple.Item1, turple.Item2))
                    {
                        Console.Clear();
                        Console.WriteLine("Authorized");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, try again");
                    }
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public static void ViewForAuthorizedUser()
        {
            Console.WriteLine("1 - Add course\n2 - Pass the course\n3 - LogOut");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    Console.Clear();
                    userService.LogOut();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}
