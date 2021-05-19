using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
