using EducationPortal.Automapper;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EducationPortal.Command.Commands
{
    public class LogInCommand : ICommand
    {
        readonly IUserService userService;

        public LogInCommand(IUserService userService)
        {
            this.userService = userService;
        }
        public int CommandNumber => 2;

        public string CommandName => "Log In";

        public void Execute()
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
                Console.WriteLine(new Exception("Something went wrong, try again"));
                Console.ResetColor();
            }
        }
    }
}
