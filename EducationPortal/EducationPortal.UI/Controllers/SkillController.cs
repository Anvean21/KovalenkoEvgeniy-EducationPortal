using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
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
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(SkillVM skillVM)
        {
            if (!(ModelState.IsValid && skillService.GetUniqueName(skillVM.Name)))
            {
                ModelState.AddModelError("","Invalid name or skill already exists");
                return RedirectToAction("SkillList");
            }
            var mappedSkill = mapper.Map<SkillVM, Skill>(skillVM);
            await skillService.AddSkill(mappedSkill);
            return RedirectToAction("SkillList");
        }

        public IActionResult SkillList()
        {
            return View();
        }
    }
}
