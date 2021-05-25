using EducationPortal.ViewModels.TestViewModels;
using FluentValidation;

namespace EducationPortal.FluentValidationModels.TestValidators
{
    public class TestValidator : AbstractValidator<TestVM>
    {
        public TestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleForEach(x => x.Questions).SetValidator(new QuestionValidator());
        }
    }
}
