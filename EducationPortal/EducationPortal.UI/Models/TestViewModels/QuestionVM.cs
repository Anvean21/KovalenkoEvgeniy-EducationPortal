using System.Collections.Generic;

namespace EducationPortal.UI.Models.TestViewModels
{
    public class QuestionVM : BasicVM
    {
        public string Name { get; set; }
        public ICollection<AnswerVM> Answers { get; set; }
    }
}
