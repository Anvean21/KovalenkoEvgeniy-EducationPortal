using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public class BookMaterialValidator : AbstractValidator<BookMaterialVM>
    {
        public BookMaterialValidator()
        {
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Pages).NotEmpty();
            RuleFor(x => x.YearOfPublish).NotEmpty().Must(x => x <= DateTime.Today.Year);
        }
    }
}
