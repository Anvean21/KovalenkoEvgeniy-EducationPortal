using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class CourseTestService : ICourseTestService
    {
        private readonly IRepository<Test> testRepository;
        public CourseTestService(IRepository<Test> testService)
        {
            this.testRepository = testService;
        }

        public async Task AddTest(Test test)
        {
            await testRepository.AddAsync(test);
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

        public async Task<Test> GetTestByName(string name)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                //TODO 
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Name.ToLower() == name.ToLower(), includes);

            return await testRepository.FindAsync(spec);
        }

        public async Task<Test> GetTestById(int Id)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                //TODO 
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Id == Id, includes);

            return await testRepository.FindAsync(spec);
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
