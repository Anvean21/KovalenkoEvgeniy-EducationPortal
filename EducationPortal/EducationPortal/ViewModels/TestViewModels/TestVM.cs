using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels.TestViewModels
{
    public class TestVM : BasicVM
    {
        public string Name { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
        public int CourseId { get; set; }
    }
}
