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
        public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public virtual ICollection<UserPassedCourses> PassedCourses { get; set; } = new List<UserPassedCourses>();
        public virtual ICollection<UserCoursesInProgress> UsersInProgresses { get; set; } = new List<UserCoursesInProgress>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
        public Test Test { get; set; }
        public virtual int TestId { get; set; }
    }
}
