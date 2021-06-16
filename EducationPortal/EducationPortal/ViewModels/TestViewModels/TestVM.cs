using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels.TestViewModels
{
    public class TestVM
    {
        public string Name { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
        public CourseVM Course { get; set; }
    }
}
