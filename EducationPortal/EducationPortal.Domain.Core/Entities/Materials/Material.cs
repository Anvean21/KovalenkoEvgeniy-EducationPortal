using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Material : BasicEntity
    {
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
