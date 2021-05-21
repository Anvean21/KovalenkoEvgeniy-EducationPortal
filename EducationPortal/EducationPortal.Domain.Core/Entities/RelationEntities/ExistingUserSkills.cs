using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core.Entities.RelationEntities
{
    public class ExistingUserSkills
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
