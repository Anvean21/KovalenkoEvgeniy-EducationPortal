using System.Collections.Generic;

namespace EducationPortal.UI.Models
{
    public class UserVM : BasicVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<SkillVM> Skills { get; set; }
        public ICollection<CourseVM> CreatedCourses { get; set; }

    }
}
