using EducationPortal.Automapper;
using EducationPortal.FluentValidationModels;
using EducationPortal.FluentValidationModels.TestValidators;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels.TestViewModels;
using System;

namespace EducationPortal.Creator
{
    public class TestCreator
    {
        readonly TestHelper testHelper = new TestHelper();
        readonly ITestService testService;
        public TestCreator(ITestService testService)
        {
            this.testService = testService;
        }

        readonly TestValidator validator = new TestValidator();
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
    }
}
