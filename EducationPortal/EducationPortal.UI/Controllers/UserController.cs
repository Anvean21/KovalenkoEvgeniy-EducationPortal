using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.FluentValidation;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EducationPortal.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly FluentUserValidator validator = new FluentUserValidator();

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            this.logger = logger;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", userVM);
            }

            var mappedUser = mapper.Map<UserVM, User>(userVM);
            userService.Register(mappedUser);

            TempData["notice"] = "Person successfully created";
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
