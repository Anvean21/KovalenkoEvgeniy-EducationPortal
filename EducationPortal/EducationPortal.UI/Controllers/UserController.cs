using EducationPortal.Domain.Core;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.FluentValidation;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationPortal.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, ISkillService skillService, IMapper mapper)
        {
            this.logger = logger;
            this.userService = userService;
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            var user = await userService.GetUserByEmail(HttpContext.User.Identity.Name);

            foreach (var item in user.UserSkills)
            {
                item.Skill = await skillService.GetSkillById(item.SkillId);
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserVM userVM)
        {
            if (!(ModelState.IsValid && await userService.GetUniqueEmail(userVM.Email)))
            {
                return View("Registration", userVM);
            }

            var mappedUser = mapper.Map<UserVM, User>(userVM);
            await userService.Register(mappedUser);

            await Authenticate(mappedUser.Email);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!userService.LogIn(loginVM.Login, loginVM.Password))
            {
                ModelState.AddModelError("", "Unknow email or password");
                return View("Login", loginVM);
            }

            await Authenticate(loginVM.Login);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}
