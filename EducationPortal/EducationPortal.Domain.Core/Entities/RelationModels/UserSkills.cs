using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities.RelationModels
{
   public class UserSkills
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int Level { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
