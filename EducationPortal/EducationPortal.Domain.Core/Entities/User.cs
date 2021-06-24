using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections.Generic;

namespace EducationPortal.Domain.Core
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserCoursesInProgress> CoursesInProgress { get; set; } = new List<UserCoursesInProgress>();
        public ICollection<UserPassedCourses> PassedCourses { get; set; } = new List<UserPassedCourses>();
        public ICollection<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
    }
}
