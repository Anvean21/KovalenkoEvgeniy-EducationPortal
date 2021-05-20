using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Helpers
{
   public static class SkillHelper
    {
        public static SkillVM SkillFullData()
        {
            SkillVM skillVM = new SkillVM();
            Console.WriteLine("Write the name of skill");
            skillVM.Name = Console.ReadLine();

            return skillVM;
        }
    }
}
