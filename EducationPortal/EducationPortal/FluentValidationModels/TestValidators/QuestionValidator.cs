using EducationPortal.ViewModels.TestViewModels;
using FluentValidation;

namespace EducationPortal.FluentValidationModels.TestValidators
{
    public class QuestionValidator : AbstractValidator<QuestionVM>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleForEach(x => x.Answers).NotNull();
        }
    }
}
