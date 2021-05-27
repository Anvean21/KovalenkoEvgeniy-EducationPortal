using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Creator
{
    public class UserConroller
    {
        readonly IUserService userService;
        public UserConroller(IUserService userService)
        {
            this.userService = userService;
        }
        readonly TestController testController = new TestController(CustomServiceProvider.Provider.GetRequiredService<ITestService>());

        readonly UserValidator validator = new UserValidator();
        public void UserCreate()
        {
            var userVM = UserHelper.UserFullData();
            if (validator.Validate(userVM).IsValid)
            {
                userService.Register(Map.MapVmToDomain<UserVM, User>(userVM));
                Dye.Succsess();
                Console.WriteLine("You have successfully registered and authorized");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(validator.Validate(userVM));
                Console.ResetColor();
            }
        }
        public void UserLogIn()
        {
            var (login, password) = UserHelper.UserLoginData();

            if (userService.LogIn(login, password))
            {
                Dye.Succsess();
                Console.WriteLine("Authorized");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(new Exception("Something went wrong, try again"));
                Console.ResetColor();
            }
        }
        public void UserLogOut()
        {
            userService.LogOut();
        }
        public void AddCourseToUserProgress(CourseVM courseVM)
        {
            if (userService.AddCourseToProgress(Map.CourseVmToDomain(courseVM)))
            {
                Dye.Succsess();
                Console.WriteLine("Course passing started!");
                Console.ResetColor();
            }
            else
            {
                Dye.Inform();
                Console.WriteLine("Continue passing");
                Console.ResetColor();
            }
        }
        public void UserPassCourse(CourseVM courseVM)
        {
            int rightAnswers = 0;
            Console.WriteLine(string.Join(". ", courseVM.Name, courseVM.Description));

            foreach (var question in courseVM.Test.Questions)
            {
                Console.WriteLine("Choose the variant");
                foreach (var answers in question.Answers)
                {
                    Console.WriteLine(answers.Name);
                }
                var userVariatnt = Console.ReadLine().Trim().Split("")[0];
                testController.AnswersCounting(question, userVariatnt, ref rightAnswers);
            }
            if (userService.IsCoursePassed(Map.CourseVmToDomain(courseVM), rightAnswers))
            {
                Dye.Succsess();
                Console.WriteLine($"Test - passed. Right answers {rightAnswers}/{courseVM.Test.Questions.Count()} CONGRATULATIONS!!!");
                Console.ResetColor();
            }
            else
            {
                Dye.Fail();
                Console.WriteLine("Learn materials hard, and try again");
                Console.ResetColor();
            }
        }
    }
}
