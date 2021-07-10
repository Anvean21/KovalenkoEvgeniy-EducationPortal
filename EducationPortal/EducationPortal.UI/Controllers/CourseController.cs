using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using EducationPortal.UI.Models.TestViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly ICourseService courseService;
        private readonly IMaterialService materialService;
        private readonly ISkillService skillService;
        private readonly ICourseTestService courseTestService;
        private readonly IMapper mapper;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService, IMaterialService materialService, ISkillService skillService, ICourseTestService courseTestService, IMapper mapper)
        {
            this.logger = logger;
            this.courseService = courseService;
            this.mapper = mapper;
            this.materialService = materialService;
            this.skillService = skillService;
            this.courseTestService = courseTestService;
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseVM courseVM)
        {

            if (!(ModelState.IsValid && await courseService.UniqueCourseName(courseVM.Name)))
            {
                return View("CreateCourse");
            }
            var mappedCourse = mapper.Map<CourseVM, Course>(courseVM);

            await courseService.AddCourse(mappedCourse);

            courseVM.Id = mappedCourse.Id;


            return RedirectToAction("CourseMaterials", new { id = courseVM.Id });
        }

        public async Task<IActionResult> CourseMaterials(int id)
        {
            ViewBag.Videos = mapper.Map<Material, MaterialVM>(materialService.GetVideoMaterials());
            ViewBag.Articles = mapper.Map<Material, MaterialVM>(materialService.GetArticleMaterials());
            ViewBag.Books = mapper.Map<Material, MaterialVM>(materialService.GetBookMaterials());

            var course = await courseService.GetById(id);
            var mappedCourse = mapper.Map<Course, CourseVM>(course);

            return View(mappedCourse);
        }

        public async Task<IActionResult> AddMaterial(int courseId, int materialId)
        {
            await courseService.AddMaterials(courseId, materialId);

            TempData["success"] = "Material added";
            return RedirectToAction("CourseMaterials", new { id = courseId });
        }

        public async Task<IActionResult> CourseSkills(int id)
        {
            ViewBag.Skills = mapper.Map<Skill, SkillVM>(skillService.GetSkills());

            var course = await courseService.GetById(id);
            if (!course.Materials.Any())
            {
                TempData["nullMaterials"] = "Materials cannot be null. Add materials";
                return RedirectToAction("CourseMaterials", new { id = course.Id });
            }
            var mappedCourse = mapper.Map<Course, CourseVM>(course);
            return View(mappedCourse);
        }

        public async Task<IActionResult> AddSkill(int courseId, int skillId)
        {

            await courseService.AddSkills(courseId, skillId);

            TempData["success"] = "Skill added";
            return RedirectToAction("CourseSkills", new { id = courseId });
        }

        public async Task<IActionResult> CourseTest(int id)
        {
            ViewBag.Test = mapper.Map<Test, TestVM>(courseTestService.GetTests());

            var course = await courseService.GetById(id);
            if (!course.Skills.Any())
            {
                TempData["nullSkills"] = "Skills cannot be null. Add skills";
                return RedirectToAction("CourseSkills", new { id = course.Id });
            }
            var mappedCourse = mapper.Map<Course, CourseVM>(course);

            return View(mappedCourse);
        }

        public async Task<IActionResult> AddTest(int courseId, int testId)
        {
            if (!await courseService.AddTest(courseId, testId))
            {
                ModelState.AddModelError("", "This test already taken");
                return RedirectToAction("CourseTest", new { id = courseId });
            }

            TempData["success"] = "Test added";
            return RedirectToAction("Index", "Home");
        }
    }
}
