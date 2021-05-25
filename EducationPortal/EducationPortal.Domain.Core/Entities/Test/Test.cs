using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities
{
    public class Test : BasicEntity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
