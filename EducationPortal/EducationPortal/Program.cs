using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Automapper;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using EducationPortal.Helpers;
using EducationPortal.Command;

namespace EducationPortal
{
    class Program
    {

        static void Main(string[] args)
        {
            IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();
            CommandManager commandManager = new CommandManager(CustomServiceProvider.Provider.GetRequiredService<ICommandProcessor>());

            while (true)
            {
                if (userService.IsUserAuthorized())
                {
                    commandManager.AuthStart();
                }
                else
                {
                    commandManager.Start();
                }
            }
        }
    }
}

