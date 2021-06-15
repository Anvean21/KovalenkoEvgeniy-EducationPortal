using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Test: BasicEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual Course Course { get; set; }
    }
}
