using Autofac;
using AutoMapper;
using EducationPortal.Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using System;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService(new JsonRepository<User>());
            UserValidator validator = new UserValidator();
            DependecyIngection.ConfigureService();

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
