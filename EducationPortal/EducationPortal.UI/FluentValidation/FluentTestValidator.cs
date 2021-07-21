using EducationPortal.UI.Models.TestViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentTestValidator : AbstractValidator<TestVM>
    {
        public FluentTestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(2,50);
            RuleForEach(x => x.Questions).SetValidator(new FluentQuestionValidator());
        }
    }
}
