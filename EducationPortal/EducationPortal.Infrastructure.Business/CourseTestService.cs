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
        private readonly IRepository<Answer> answerRepository;

        public CourseTestService(IRepository<Test> testService, IRepository<Answer> answerRepository)
        {
            this.testRepository = testService;
            this.answerRepository = answerRepository;
        }

        public async Task AddTest(Test test)
        {
            await testRepository.AddAsync(test);
        }

        public async Task<bool> UniqueTestName(string name)
        {
            var courseSpecification = new Specification<Test>(x => x.Name.ToLower() == name.ToLower());

            if (await testRepository.FindAsync(courseSpecification) == null)
            {
                return true;
            }

            return false;
        }

        public async Task<Test> GetTestByName(string name)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Name.ToLower() == name.ToLower(), includes);

            return await testRepository.FindAsync(spec);
        }

        public async Task<Test> GetTestById(int? Id)
        {
            var includes = new List<Expression<Func<Test, object>>>
            {
                y => y.Questions
            };

            var spec = new Specification<Test>(x => x.Id == Id, includes);

            return await testRepository.FindAsync(spec);
        }

        public IEnumerable<Test> GetTests()
        {
            var spec = new Specification<Test>(x => x.Taken == false);

            return testRepository.GetAsync(spec, 1, 20).Result.Items;
        }

        public async Task<int> CountRightUserAnswers(List<int> answersId)
        {
            var answers = new List<Answer>();

            foreach (var id in answersId)
            {
                var answerSpecification = new Specification<Answer>(x => x.Id == id && x.IsTrue == true);
                var rightAnswer = await answerRepository.FindAsync(answerSpecification);
                if (rightAnswer != null)
                {
                    answers.Add(rightAnswer);
                }
            }

            return answers.Count();
        }
    }
}
