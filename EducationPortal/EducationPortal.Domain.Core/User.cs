using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class User : BasicEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




        //public Skill Skills  { get; set; }

        //public Course Courses { get; set; }

    }
}
