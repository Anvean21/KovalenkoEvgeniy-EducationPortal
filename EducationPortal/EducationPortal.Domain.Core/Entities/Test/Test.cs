using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Course Course { get; set; }
    }
}
