using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    [Serializable]
    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public Role Role { get; set; }

        //public Skill Skills  { get; set; }

        //public Course Courses { get; set; }

    }
}
