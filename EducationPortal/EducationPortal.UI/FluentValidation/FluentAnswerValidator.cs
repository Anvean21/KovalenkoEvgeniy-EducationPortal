using EducationPortal.UI.Models.TestViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentAnswerValidator : AbstractValidator<AnswerVM>
    {
        public FluentAnswerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(1,60);
            RuleFor(x => x.IsTrue).NotEmpty();
        }
    }
}
