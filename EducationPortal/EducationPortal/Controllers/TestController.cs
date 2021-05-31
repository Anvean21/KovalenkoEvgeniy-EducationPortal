using EducationPortal.Automapper;
using EducationPortal.FluentValidationModels;
using EducationPortal.FluentValidationModels.TestValidators;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels.TestViewModels;
using System;

namespace EducationPortal.Creator
{
    public class TestController
    {
        readonly TestHelper testHelper = new TestHelper();
        readonly ITestService testService;
        readonly TestValidator validator = new TestValidator();

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        public TestVM TestCreate()
        {
            var testVM = testHelper.TestFullData();
            if (validator.Validate(testVM).IsValid)
            {
                testService.AddTest(Map.TestVmToDomain(testVM));
                Dye.Succsess();
                Console.WriteLine("You have successfully created test");
                Console.ResetColor();
                return testVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(testVM));
                Console.ResetColor();
                TestCreate();
                return null;
            }
        }
        public int AnswersCounting(QuestionVM questionVM, string userVariant, ref int result)
        {
            return testService.CountResult(Map.QuestionVmToDomain(questionVM), userVariant, ref result);
        }
    }
}
