using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Test : BasicEntity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
