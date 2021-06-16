using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Question : BasicEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } 
    }
}
