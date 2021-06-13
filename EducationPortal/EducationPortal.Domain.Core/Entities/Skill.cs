using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Skill 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserSkills> UserSkills { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
