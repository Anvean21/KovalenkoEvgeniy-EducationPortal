using EducationPortal.UI.Models.TestViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.FluentValidation
{
    public class FluentQuestionValidator : AbstractValidator<QuestionVM>
    {
        public FluentQuestionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3,128);
            RuleForEach(x => x.Answers).NotEmpty();
        }
    }
}
