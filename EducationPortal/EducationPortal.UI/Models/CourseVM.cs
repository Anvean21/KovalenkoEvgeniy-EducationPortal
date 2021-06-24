using EducationPortal.UI.Models.TestViewModels;
using System.Collections.Generic;

namespace EducationPortal.UI.Models
{
    public class CourseVM : BasicVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SkillVM> Skills { get; set; }
        public ICollection<MaterialVM> Materials { get; set; }
        public TestVM Test { get; set; }
        public int TestId { get; set; }
    }
}
