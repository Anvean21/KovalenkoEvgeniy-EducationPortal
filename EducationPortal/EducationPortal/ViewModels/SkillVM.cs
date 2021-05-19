using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationPortal.ViewModels
{
    public class SkillVM : BasicVM
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
