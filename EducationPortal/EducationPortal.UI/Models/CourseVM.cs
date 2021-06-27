using EducationPortal.UI.Models.TestViewModels;
using System.Collections.Generic;

namespace EducationPortal.UI.Models
{
    public class CourseVM : BasicVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool Created { get; set; }
        public ICollection<SkillVM> Skills { get; set; } = new List<SkillVM>();
        public ICollection<MaterialVM> Materials { get; set; } = new List<MaterialVM>();
        public TestVM Test { get; set; }
        public int TestId { get; set; }
    }
}
