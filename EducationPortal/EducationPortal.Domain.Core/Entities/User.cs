using EducationPortal.Domain.Core.Entities.RelationEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Course> CourseInProgress { get; set; }
        [JsonIgnore]
        public IList<ExistingUserSkills> ExistingUserSkills { get; set; }

    }
}
