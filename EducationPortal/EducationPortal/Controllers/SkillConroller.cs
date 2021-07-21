using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;

namespace EducationPortal.Creator
{
    public class SkillConroller
    {
        readonly ISkillService skillService;
        readonly SkillValidator validator = new SkillValidator();
        private readonly IMapper mapper;


        public SkillConroller(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        public SkillVM SkillCreate()
        {
            var skillVM = SkillHelper.SkillFullData();
            if (validator.Validate(skillVM).IsValid)
            {
                var mappedSkill = mapper.Map<SkillVM, Skill>(skillVM);
                skillService.AddSkill(mappedSkill);

                Dye.Succsess();
                Console.WriteLine("Skill has successfully added");
                Console.ResetColor();
                return skillVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(skillVM));
                Console.ResetColor();
                SkillCreate();
                return null;
            }
        }

        public void SkillsList()
        {
            foreach (var skill in skillService.GetSkills())
            {
                Console.Write(skill.Name + " , ");
            }
        }

        public SkillVM AddSkillByName(string name)
        {
            var skillByName = skillService.GetSkillByName(name).Result;
            var mappedSkillVM = mapper.Map<Skill, SkillVM>(skillByName);
            return mappedSkillVM;
        }
    }
}
