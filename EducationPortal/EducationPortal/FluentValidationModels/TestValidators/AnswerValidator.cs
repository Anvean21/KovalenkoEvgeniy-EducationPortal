using EducationPortal.ViewModels.TestViewModels;
using FluentValidation;

namespace EducationPortal.FluentValidationModels.TestValidators
{
    public class AnswerValidator : AbstractValidator<AnswerVM>
    {
        public AnswerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IsTrue).NotEmpty();
        }
    }
}
