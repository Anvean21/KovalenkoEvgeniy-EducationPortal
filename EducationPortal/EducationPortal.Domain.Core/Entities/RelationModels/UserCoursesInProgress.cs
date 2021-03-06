using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities.RelationModels
{
    public class UserCoursesInProgress
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
