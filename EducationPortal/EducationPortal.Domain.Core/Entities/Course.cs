using AutoMapper.Configuration.Annotations;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Core.Entities.RelationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<UserPassedCourses> PassedCourses { get; set; }
        public virtual ICollection<UserCoursesInProgress> UsersInProgresses { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual Test Test { get; set; }
        public virtual int TestId { get; set; }
    }
}
