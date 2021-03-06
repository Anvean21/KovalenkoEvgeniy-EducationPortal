using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.Models;
using EducationPortal.UI.Models.TestViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class CoursePassController : Controller
    {
        private readonly ILogger<CoursePassController> logger;
        private readonly ICourseService courseService;
        private readonly IUserService userService;
        private readonly IMaterialService materialService;
        private readonly ICourseTestService courseTestService;
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;

        public CoursePassController(ILogger<CoursePassController> logger, ICourseService courseService, IUserService userService, IMaterialService materialService, ICourseTestService courseTestService, IQuestionService questionService, IMapper mapper)
        {
            this.logger = logger;
            this.courseService = courseService;
            this.userService = userService;
            this.mapper = mapper;
            this.materialService = materialService;
            this.courseTestService = courseTestService;
            this.questionService = questionService;
        }

        public IActionResult CourseList()
        {
            var courses = courseService.GetCourses();
            var mappedCourses = mapper.Map<Course, CourseVM>(courses);
            return View(mappedCourses);
        }
        public async Task<IActionResult> PassCourse(int courseId)
        {
            var user = await userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var course = await courseService.GetById(courseId);

            if (course == null || user == null)
            {
                //не верный айдишник курса
                return RedirectToAction("CourseList", "CoursePass");
            }

            if (await userService.AddCourseToProgress(user, course))
            {
                var mappedCourse = mapper.Map<Course, CourseVM>(course);

                var videoMaterials = new List<VideoMaterialVM>();
                var bookMaterials = new List<BookMaterialVM>();
                var articleMaterials = new List<ArticleMaterialVM>();

                foreach (var material in course.Materials)
                {
                    var materialk = await materialService.GetMaterialById(material.Id);
                    var materialVM = mapper.Map<Material, MaterialVM>(materialk);

                    if (materialVM is VideoMaterialVM videoMaterial)
                    {
                        videoMaterials.Add(videoMaterial);
                    }
                    if (materialVM is BookMaterialVM bookMaterial)
                    {
                        bookMaterials.Add(bookMaterial);
                    }
                    if (materialVM is ArticleMaterialVM articleMaterial)
                    {
                        articleMaterials.Add(articleMaterial);
                    }
                }

                PassCourseVM passCourseVM = new PassCourseVM
                {
                    CourseVM = mappedCourse,
                    Videos = videoMaterials,
                    Articles = articleMaterials,
                    Books = bookMaterials
                };
                TempData["passingStarted"] = "Course passing started";

                return View(passCourseVM);
            }

            else
            {
                //вы уже проходили этот курс раньше
                TempData["testAlreadyPassed"] = "This test has already been passed by you";
                return RedirectToAction("CourseList", "CoursePass");
            }
        }

        [HttpGet]
        public async Task<IActionResult> PassTest(int courseId)
        {
            var course = await courseService.GetById(courseId);
            var test = await courseTestService.GetTestById(course.TestId);
            var mappedTest = mapper.Map<Test, TestVM>(test);

            foreach (var question in mappedTest.Questions)
            {
                question.Answers.AddRange(mapper.Map<Answer, AnswerVM>(await questionService.GetAnswers(question.Id)));
            }

            return View(mappedTest);
        }

        public async Task<IActionResult> TestResult(string results, string testId)
        {
            var user = await userService.GetUserByEmail(HttpContext.User.Identity.Name);
            var course = await courseService.GetByTestId(int.Parse(testId));
            var listResult = new List<int>();

            if (results == null)
            {
                RedirectToAction("PassTest", "CoursePass", new { courseId = course.Id });
            }

            foreach (var item in results.Split(','))
            {
                int.TryParse(item, out int result);
                listResult.Add(result);
            }

            var rightAnswers = await courseTestService.CountRightUserAnswers(listResult);

            if (await userService.IsCoursePassed(user, course, rightAnswers))
            {
                TempData["testPassed"] = "Congratulations. Exam test passed! You have got new skills";
            }
            else
            {
                TempData["testFail"] = "Test is not passed. Learn materials hard and try again!";
            }

            return View();
        }
    }
}
