using EducationPortal.Domain.Core.Entities;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Course : BasicEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual Test Test { get; set; }
    }
}
