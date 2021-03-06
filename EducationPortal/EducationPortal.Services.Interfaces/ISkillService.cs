using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface ISkillService
    {
        public Task AddSkill(Skill skill);
        public IEnumerable<Skill> GetSkills(int pageNumber = 1, int itemCount = 10);
        public Task<Skill> GetSkillByName(string name);
        public Task<bool> GetUniqueName(string name);
        public Task<Skill> GetSkillById(int skillId);
    }
}
