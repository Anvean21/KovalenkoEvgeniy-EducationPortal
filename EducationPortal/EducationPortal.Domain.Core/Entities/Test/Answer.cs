using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities
{
    public class Answer : BasicEntity
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
    }
}
