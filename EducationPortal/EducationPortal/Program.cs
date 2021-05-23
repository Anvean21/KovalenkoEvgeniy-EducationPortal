using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Automapper;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using EducationPortal.Helpers;

namespace EducationPortal
{
    class Program
    {
        private static readonly IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();
        readonly static ConsoleView ConsoleView = new ConsoleView();
        static void Main(string[] args)
        {
            while (true)
            {
                if (userService.IsUserAuthorized())
                {
                    ConsoleView.ViewForAuthorizedUser();
                }
                else
                {
                    ConsoleView.ViewForUnautorizedUser();
                }
            }
        }
    }
}

