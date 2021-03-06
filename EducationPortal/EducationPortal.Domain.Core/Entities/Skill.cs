using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public ICollection<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
