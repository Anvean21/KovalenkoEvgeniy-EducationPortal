using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        }

        public bool UniqueTestName(string name)
        {
            var courseSpecification = new Specification<Test>(x => x.Name.ToLower() == name.ToLower());

            if (testRepository.FindAsync(courseSpecification).Result == null)
            {
                return true;
            }

            return false;
        }

        public Test GetTestByName(string name)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                //TODO 
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Name.ToLower() == name.ToLower(), includes);

            return testRepository.FindAsync(spec).Result;
        }

        public Test GetTestById(int Id)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                //TODO 
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Id == Id, includes);

            return testRepository.FindAsync(spec).Result;
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
