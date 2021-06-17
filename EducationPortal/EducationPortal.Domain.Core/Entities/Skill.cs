using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
