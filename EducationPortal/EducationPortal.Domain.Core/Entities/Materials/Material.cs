using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Material : BasicEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
