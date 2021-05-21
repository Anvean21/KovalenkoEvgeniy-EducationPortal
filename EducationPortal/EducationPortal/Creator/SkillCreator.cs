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
                Console.Clear();
                Console.WriteLine("Skill has successfully added");
                return skillVM;
            }
            else
            {
                validator.ValidateAndThrow(skillVM);
                return null;
            }
        }
        public static void SkillsList()
        {
            foreach (var skill in skillService.GetSkills())
            {
                Console.WriteLine(string.Join(", ", skill.Name));
            }
        }
        public static SkillVM AddSkillByName(string name)
        {
            return Map.MapVmToDomain<Skill, SkillVM>(skillService.GetSkillByName(name));
        }
    }
}
