using EducationPortal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
   public interface IQuestionService
    {
        public Task<IEnumerable<Answer>> GetAnswers(int questionId);
    }
}
