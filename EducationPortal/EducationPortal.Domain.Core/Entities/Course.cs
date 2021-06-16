using AutoMapper.Configuration.Annotations;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Core.Entities.RelationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class Course : BasicEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<UserPassedCourses> UsersPassed { get; set; }
        public virtual ICollection<UserCoursesInProgress> UsersInProgresses { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual Test Test { get; set; }
    }
}
