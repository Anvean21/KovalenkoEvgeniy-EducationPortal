using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class Course : BasicEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Skill> Skills { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
