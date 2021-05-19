using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EducationPortal.FluentValidationModels
{
    public class UserValidator : AbstractValidator<UserVM>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2, 50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Length(6, 30);
        }
    }
}
