using System.Collections.Generic;

namespace EducationPortal.UI.Models.TestViewModels
{
    public class TestVM : BasicVM
    {
        public string Name { get; set; }
        public bool Taken { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
        public int Result { get; set; }
    }
}
