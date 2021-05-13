using EducationPortal.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EducationPortal.FluentValidationModels
{
  public  class UserValidator:AbstractValidator<UserVM>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Invalid name length");
            //Непонятно как использовать регулярку для валидации эмэйла
            Regex reg = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(30).WithMessage("Invalid password length, min. 6 symbols");
        }
    }
}
