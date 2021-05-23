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

namespace EducationPortal.Creator
{
    public class UserCreator
    {
        private static readonly IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();
        static UserValidator validator = new UserValidator();
        public static void UserCreate()
        {
            var userVM = UserHelper.UserFullData();
            if (validator.Validate(userVM).IsValid)
            {
                userService.Register(Map.MapVmToDomain<UserVM, User>(userVM));
                Dye.Succsess();
                Console.WriteLine("You have successfully registered and authorized");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(userVM));
                Console.ResetColor();
            }
        }
        public static void UserLogIn()
        {
            var turple = UserHelper.UserLoginData();

            if (userService.LogIn(turple.login, turple.password))
            {
                Dye.Succsess();
                Console.WriteLine("Authorized");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine("Something went wrong, try again");
                Console.ResetColor();
            }
        }
        public static void UserLogOut()
        {
            userService.LogOut();
        }

    }
}
