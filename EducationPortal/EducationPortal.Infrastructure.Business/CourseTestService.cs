using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class CourseTestService : ICourseTestService
    {
        private readonly IRepository<Test> testRepository;
        public CourseTestService(IRepository<Test> testService)
        {
            this.testRepository = testService;
        }

        public void AddTest(Test test)
        {
            testRepository.AddAsync(test);
            testRepository.SaveAsync();
        }
        
        public Test GetTest(string name)
        {
            var testSpec = new Specification<Test>(x => x.Name.ToLower() == name.ToLower());
            return testRepository.FindAsync(testSpec).Result;
        }

        public int CountResult(Question question, string userVariant, ref int result)
        {
            if (userVariant == question.Answers.FirstOrDefault(x => x.IsTrue == true).Name.Split(".")[0])
            {
                result++;
            }

            return result;
        }
    }
}
