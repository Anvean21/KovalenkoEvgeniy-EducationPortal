using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
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
            skillRepository.AddAsync(skill);
            skillRepository.SaveAsync();
        }

        public Skill GetSkillByName(string name)
        {
            var materialSpecification = new Specification<Skill>(x => x.Name.ToLower() == name.ToLower());

            return skillRepository.FindAsync(materialSpecification).Result;
        }

        public IEnumerable<Skill> GetSkills(int pageNumber = 1, int itemCount = 10)
        {
            var materialSpecification = new Specification<Skill>(x => x.Id == x.Id);

            return skillRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }
    }
}
