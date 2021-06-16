using EducationPortal.Domain.Core.Entities.RelationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class Material : BasicEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}
