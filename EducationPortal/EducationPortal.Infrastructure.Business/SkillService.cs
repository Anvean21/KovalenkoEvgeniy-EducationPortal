using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task AddSkill(Skill skill)
        {
            await skillRepository.AddAsync(skill);
        }

        public bool GetUniqueName(string name)
        {
            var skillSpecification = new Specification<Skill>(x => x.Name.ToLower() == name.ToLower());

            if (skillRepository.FindAsync(skillSpecification).Result == null)
            {
                return true;
            }

            return false;
        }

        public async Task<Skill> GetSkillByName(string name)
        {
            var materialSpecification = new Specification<Skill>(x => x.Name.ToLower() == name.ToLower());

            return await skillRepository.FindAsync(materialSpecification);
        }

        public IEnumerable<Skill> GetSkills(int pageNumber = 1, int itemCount = 10)
        {
            var materialSpecification = new Specification<Skill>(x => true);

            return skillRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }
    }
}
