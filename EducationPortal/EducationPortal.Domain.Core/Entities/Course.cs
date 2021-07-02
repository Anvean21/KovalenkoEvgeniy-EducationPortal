using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class Course : BasicEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Created { get; set; }
        public ICollection<UserCoursesInProgress> UsersInProgress { get; set; } = new List<UserCoursesInProgress>();
        public ICollection<UserPassedCourses> UsersPassed { get; set; } = new List<UserPassedCourses>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Material> Materials { get; set; } = new List<Material>();
        public Test Test { get; set; }
        public int? TestId { get; set; }
    }
}
