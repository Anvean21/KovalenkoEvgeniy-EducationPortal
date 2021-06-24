using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels.TestViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.FluentValidationModels.TestValidators
{
    public class TestValidator : AbstractValidator<TestVM>
    {
        private static readonly ICourseTestService testService = CustomServiceProvider.Provider.GetRequiredService<ICourseTestService>();

        public TestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Must(UniqueTestName);
            RuleForEach(x => x.Questions).SetValidator(new QuestionValidator());
        }

        private bool UniqueTestName(string uniqeItem)
        {
            if (testService.UniqueTestName(uniqeItem))
            {
                return true;
            }
            return false;
        }
    }
}
