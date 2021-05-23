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
        readonly IUserService userService;
        public UserCreator(IUserService userService)
        {
            this.userService = userService;
        }

        readonly UserValidator validator = new UserValidator();
        public void UserCreate()
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
        public void UserLogIn()
        {
            var (login, password) = UserHelper.UserLoginData();

            if (userService.LogIn(login, password))
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
        public void UserLogOut()
        {
            userService.LogOut();
        }
    }
}
