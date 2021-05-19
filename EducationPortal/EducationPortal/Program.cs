using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EducationPortal
{
    class Program
    {
        private static readonly IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();
        static void Main(string[] args)
        {
            UserValidator validator = new UserValidator();
            while (true)
            {
                Console.WriteLine("1 - Registration\n2 - Log In\n3 - Clear ");
                switch (Console.ReadLine())
                {
                    case "1":
                        var userVM = UserHelper.UserFullData();

                        if (validator.Validate(userVM).IsValid)
                        {
                            userService.Register(Map.MapVmToDomain<UserVM, User>(userVM));
                        }
                        else
                        {
                            validator.ValidateAndThrow(userVM);
                        }
                        break;
                    case "2":
                        var turple = UserHelper.UserLoginData();

                        if (userService.LogIn(turple.Item1, turple.Item2))
                        {
                            Console.WriteLine("Authorized");
                        }
                        else
                        {
                            Console.WriteLine("User is not found");
                        }
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
