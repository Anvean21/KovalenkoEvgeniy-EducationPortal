using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class CourseTestService : ICourseTestService
    {
        private readonly IRepository<Test> testService;
        public CourseTestService(IRepository<Test> testService)
        {
            this.testService = testService;
        }

        public void AddTest(Test test)
        {
            testService.Create(test);
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
