using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EducationPortal.FluentValidationModels
{
    public class UserValidator : AbstractValidator<UserVM>
    {
        private static readonly IUserService userService = CustomServiceProvider.Provider.GetRequiredService<IUserService>();

        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(UniqueEmail).WithMessage("Email is already taken");
            RuleFor(x => x.Password).NotEmpty().Length(6, 30);
        }

        private bool UniqueEmail(string uniqeItem)
        {
            if (userService.GetUniqueEmail(uniqeItem))
            {
                return true;
            }
            return false;
        }
    }
}
