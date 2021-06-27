using AutoMapper;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Models.TestViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> logger;
        private readonly ICourseTestService testService;
        private readonly IMapper mapper;

        public TestController(ILogger<TestController> logger, ICourseTestService testService, IMapper mapper)
        {
            this.logger = logger;
            this.testService = testService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestVM testVM)
        {
            if (!(ModelState.IsValid && testService.UniqueTestName(testVM.Name)))
            {
                return View("CreateTest", testVM);
            }

            var mapped = mapper.Map<TestVM, Test>(testVM);
            await testService.AddTest(mapped);
            return View();
        }

        [HttpGet]
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQuestion(QuestionVM questionVM)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateQuestion", questionVM);
            }
            return View();
        }
    }
}
