using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Creator
{
    public class SkillCreator
    {
        private static readonly ISkillService skillService = CustomServiceProvider.Provider.GetRequiredService<ISkillService>();
        static SkillValidator validator = new SkillValidator();

        public static SkillVM SkillCreate()
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
        public static void SkillsList()
        {
            foreach (var skill in skillService.GetSkills())
            {
                Console.Write(skill.Name + " , ");
            }
        }
        public static SkillVM AddSkillByName(string name)
        {
            return Map.MapVmToDomain<Skill, SkillVM>(skillService.GetSkillByName(name));
        }
    }
}
