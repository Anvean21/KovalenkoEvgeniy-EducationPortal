﻿using EducationPortal.Automapper;
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
        public SkillConroller(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        readonly SkillValidator validator = new SkillValidator();

        public SkillVM SkillCreate()
        {
            var skillVM = SkillHelper.SkillFullData();
            if (validator.Validate(skillVM).IsValid)
            {
                skillService.AddSkill(Map.MapVmToDomain<SkillVM, Skill>(skillVM));
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
            return Map.MapVmToDomain<Skill, SkillVM>(skillService.GetSkillByName(name));
        }
    }
}
