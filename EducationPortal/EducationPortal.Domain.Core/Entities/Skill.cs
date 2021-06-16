using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<UserSkills> UserSkills { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
