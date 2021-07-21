using EducationPortal.Automapper;
using EducationPortal.Creator;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command.Commands
{
    public class RegisterCommand : ICommand
    {
        readonly IUserService userService;
        readonly UserValidator validator = new UserValidator();
        private readonly IMapper mapper;

        public RegisterCommand(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public int CommandNumber => 1;
        public string CommandName => "Register";

        public void Execute()
        {
            Console.Clear();
            var userVM = UserHelper.UserFullData();
            if (validator.Validate(userVM).IsValid)
            {
                userService.Register(mapper.Map<UserVM, User>(userVM));
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
    }
}
