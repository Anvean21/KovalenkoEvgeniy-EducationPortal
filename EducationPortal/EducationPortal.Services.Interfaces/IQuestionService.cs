using EducationPortal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
   public interface IQuestionService
    {
        public IEnumerable<Answer> GetAnswers(int questionId);
    }
}
