using EducationPortal.Automapper;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.FluentValidationModels;
using EducationPortal.FluentValidationModels.TestValidators;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;

namespace EducationPortal.Creator
{
    public class TestController
    {
        readonly TestHelper testHelper = new TestHelper();
        readonly ICourseTestService testService;
        readonly TestValidator validator = new TestValidator();
        private readonly IMapper mapper;

        public TestController(ICourseTestService testService, IMapper mapper)
        {
            this.testService = testService;
            this.mapper = mapper;
        }

        public TestVM TestCreate()
        {
            var testVM = testHelper.TestFullData();
            if (validator.Validate(testVM).IsValid)
            {
                testService.AddTest(mapper.Map<TestVM, Test>(testVM));
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

        public TestVM GetTestByName(string name)
        {
            return mapper.Map<Test, TestVM>(testService.GetTest(name));
        }

        public int AnswersCounting(QuestionVM questionVM, string userVariant, ref int result)
        {
            return testService.CountResult(mapper.Map<QuestionVM, Question>(questionVM), userVariant, ref result);
        }
    }
}
