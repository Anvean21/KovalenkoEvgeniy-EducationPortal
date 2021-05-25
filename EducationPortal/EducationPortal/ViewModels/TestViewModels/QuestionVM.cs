using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels.TestViewModels
{
    public class QuestionVM
    {
        public string Name { get; set; }
        public ICollection<AnswerVM> Answers { get; set; }
    }
}
