﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels
{
    public class CourseVM : BasicVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SkillVM> Skills { get; set; }
        public ICollection<MaterialVM> Materials { get; set; }
    }
}
