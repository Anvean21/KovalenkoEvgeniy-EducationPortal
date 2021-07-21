using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities.RelationModels;
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

        public async Task<bool> GetUniqueName(string name)
        {
            var skillSpecification = new Specification<Skill>(x => x.Name.ToLower() == name.ToLower());

            if (await skillRepository.FindAsync(skillSpecification) == null)
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
            var skillSpecification = new Specification<Skill>(x => true);

            return skillRepository.GetAsync(skillSpecification, pageNumber, itemCount).Result.Items;
        }
        public async Task<Skill> GetSkillById(int skillId)
        {
            var skillSpecification = new Specification<Skill>(x => x.Id == skillId);

            return await skillRepository.FindAsync(skillSpecification);
        }
    }
}
