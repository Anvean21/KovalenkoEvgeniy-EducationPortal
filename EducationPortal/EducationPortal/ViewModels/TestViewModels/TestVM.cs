using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels.TestViewModels
{
    public class TestVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<QuestionVM> Questions { get; set; }
        public CourseVM Course { get; set; }
        public int CourseId { get; set; }
    }
}
