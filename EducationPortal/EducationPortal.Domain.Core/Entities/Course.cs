using EducationPortal.Domain.Core.Entities;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Course : BasicEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Material> Materials { get; set; } = new List<Material>();
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
