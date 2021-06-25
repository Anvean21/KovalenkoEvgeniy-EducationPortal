using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper mapper;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService, IMapper mapper)
        {
            this.logger = logger;
            this.courseService = courseService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(CourseVM courseVM)
        {
            var mappedCourse = mapper.Map<CourseVM, Course>(courseVM);
            courseService.AddCourse(mappedCourse);

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
