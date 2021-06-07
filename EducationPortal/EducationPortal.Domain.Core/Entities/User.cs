using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Course> CourseInProgress { get; set; } = new List<Course>();

    }
}
