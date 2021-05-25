using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities
{
    public class Question
    {
        public string Name { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
