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
                var mappedTest = mapper.Map<TestVM, Test>(testVM);
                testService.AddTest(mappedTest);

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

        public TestVM GetTestById(int Id)
        {
            var testById = testService.GetTestById(Id).Result;
            var mappedTestVM = mapper.Map<Test, TestVM>(testById);

            return mappedTestVM;
        }

        public TestVM GetTestByName(string name)
        {
            var testByName = testService.GetTestByName(name).Result;
            var mappedTestVM = mapper.Map<Test, TestVM>(testByName);

            return mappedTestVM;
        }

        public int AnswersCounting(QuestionVM questionVM, string userVariant, ref int result)
        {
            var mappedQuestion = mapper.Map<QuestionVM, Question>(questionVM);

            return testService.CountResult(mappedQuestion, userVariant, ref result);
        }
    }
}
