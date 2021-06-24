using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface ISkillService
    {
        public void AddSkill(Skill skill);
        public IEnumerable<Skill> GetSkills(int pageNumber = 1, int itemCount = 10);
        public Task<Skill> GetSkillByName(string name);
        public bool GetUniqueName(string name);
    }
}
