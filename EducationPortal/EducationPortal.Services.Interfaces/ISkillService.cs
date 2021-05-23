using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface ISkillService
    {
        public void AddSkill(Skill skill);
        public IEnumerable<Skill> GetSkills();
        public Skill GetSkillByName(string name);
    }
}
