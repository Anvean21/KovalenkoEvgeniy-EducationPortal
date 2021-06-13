using EducationPortal.Domain.Core.Entities.RelationModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public virtual ICollection<Course> CreatedCourses { get; set; }
        public virtual ICollection<UserCoursesInProgress> CourseInProgress { get; set; } = new List<UserCoursesInProgress>();
        public virtual ICollection<UserPassedCourses> PassedCourses { get; set; } = new List<UserPassedCourses>();
        public virtual ICollection<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
    }
}
