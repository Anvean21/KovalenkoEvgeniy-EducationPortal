using EducationPortal.Automapper;
using EducationPortal.Command.Interfaces;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EducationPortal.Command.Commands
{
    public class LogOutCommand : IAuthCommand
    {
        readonly IUserService userService;

        public LogOutCommand(IUserService userService)
        {
            this.userService = userService;
        }
        public int CommandNumber => 3;

        public string CommandName => "Log Out";

        public void Execute()
        {
            userService.LogOut();
            Dye.Fail();
            Console.WriteLine("LogOut");
            Console.ResetColor();
        }
    }
}
