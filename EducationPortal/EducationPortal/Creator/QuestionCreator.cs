using EducationPortal.FluentValidationModels;
using EducationPortal.FluentValidationModels.TestValidators;
using EducationPortal.Helpers;
using EducationPortal.ViewModels.TestViewModels;
using System;

namespace EducationPortal.Creator
{
    public class QuestionCreator
    {
        readonly QuestionHelper questionHelper = new QuestionHelper();
        private readonly QuestionValidator validator = new QuestionValidator();
        public QuestionVM QuestionCreate()
        {
            var questionVM = questionHelper.QuestionData();
            if (validator.Validate(questionVM).IsValid)
            {
                Dye.Succsess();
                Console.WriteLine("You have successfully created question");
                Console.ResetColor();
                return questionVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(questionVM));
                Console.ResetColor();
                QuestionCreate();
                return null;
            }
        }
    }
}
