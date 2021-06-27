using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;
        private readonly IMapper mapper;
        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(SkillVM skillVM)
        {
            //skillVM.Level = 0;
            if (!(ModelState.IsValid && skillService.GetUniqueName(skillVM.Name)))
            {
                return View("CreateSkill", skillVM);
            }
            var mappedSkill = mapper.Map<SkillVM, Skill>(skillVM);
            await skillService.AddSkill(mappedSkill);
            return View();
        }

        public IActionResult SkillList()
        {
            return View();
        }
    }
}
