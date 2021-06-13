using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public void AddSkill(Skill skill)
        {
            skillRepository.Create(skill);
        }

        public Skill GetSkillByName(string name)
        {
            return skillRepository.GetAsync(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public IEnumerable<Skill> GetSkills()
        {
            return skillRepository.GetAsync();
        }
    }
}
