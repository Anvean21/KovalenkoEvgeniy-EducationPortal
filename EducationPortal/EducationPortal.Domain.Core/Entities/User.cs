using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Course> CourseInProgress { get; set; } = new List<Course>();
        public virtual ICollection<Course> PassedCourses { get; set; } = new List<Course>();
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}
