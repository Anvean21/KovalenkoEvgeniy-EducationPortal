using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> logger;
        private readonly ICourseService courseService;
        private readonly IMaterialService materialService;
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService, IMaterialService materialService, ISkillService skillService, IMapper mapper)
        {
            this.logger = logger;
            this.courseService = courseService;
            this.mapper = mapper;
            this.materialService = materialService;
            this.skillService = skillService;
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            var videoMaterials = mapper.Map<Material, MaterialVM>(materialService.GetVideoMaterials());
            var articleMaterials = mapper.Map<Material, MaterialVM>(materialService.GetArticleMaterials());
            var bookMaterials = mapper.Map<Material, MaterialVM>(materialService.GetBookMaterials());
            var skills = mapper.Map<Skill, SkillVM>(skillService.GetSkills());

            ViewBag.Videos = new MultiSelectList(videoMaterials, "Id", "Name");
            ViewBag.Articles = new MultiSelectList(articleMaterials, "Id", "Name");
            ViewBag.Books = new MultiSelectList(bookMaterials, "Id", "Name");
            ViewBag.Skills = new MultiSelectList(skills, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseVM courseVM)
        {

            if (!(ModelState.IsValid && courseService.UniqueCourseName(courseVM.Name)))
            {
                return View("CreateCourse");
            }
            var mappedCourse = mapper.Map<CourseVM, Course>(courseVM);

            await courseService.AddCourse(mappedCourse);
            courseVM.Id = mappedCourse.Id;

            return View("Index", "Home");
        }

        public IActionResult AddMaterial(int materialId, CourseVM course)
        {
            var material = mapper.Map<Material, MaterialVM>(materialService.GetMaterialById(materialId).Result);

            if (course.Materials != null && course.Materials.Any(x => x.Name == material.Name))
            {
                ModelState.AddModelError("", "Material alredy exist");
                return View("CreateCourse", course);
            }

            course.Materials.Add(material);

            return View("CreateCourse");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
