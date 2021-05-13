using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels
{
   public class UserVM:BasicVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<SkillVM> Skills { get; set; }

    }
}
