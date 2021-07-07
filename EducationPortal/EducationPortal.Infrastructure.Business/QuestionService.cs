using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Answer> answerRepository;

        public QuestionService(IRepository<Answer> answerRepository)
        {
            this.answerRepository = answerRepository;
        }

        public async Task<IEnumerable<Answer>> GetAnswers(int questionId)
        {
            var answerSpecification = new Specification<Answer>(x => x.QuestionId == questionId);

           return await answerRepository.GetAsync(answerSpecification);
        }
    }
}
