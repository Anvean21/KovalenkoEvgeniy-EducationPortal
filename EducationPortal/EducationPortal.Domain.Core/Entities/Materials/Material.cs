using EducationPortal.Domain.Core.Entities.RelationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class Material : BasicEntity
    {
        public string Name { get; set; }
        public bool Passed { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
