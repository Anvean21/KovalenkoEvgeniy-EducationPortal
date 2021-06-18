using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
