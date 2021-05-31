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
        readonly TestController testController;
        readonly UserValidator validator = new UserValidator();
        private readonly Map mapper = new Map();

        public UserConroller(IUserService userService, TestController testController)
        {
            this.userService = userService;
            this.testController = testController;
        }

        public void UserCreate()
        {
            var userVM = UserHelper.UserFullData();
            if (validator.Validate(userVM).IsValid)
            {
                userService.Register(mapper.MapVmToDomain<UserVM, User>(userVM));
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
        public bool AddCourseToUserProgress(CourseVM courseVM)
        {
            if (userService.AddCourseToProgress(mapper.CourseVmToDomain(courseVM)))
            {
                Dye.Succsess();
                Console.WriteLine("Course passing started!");
                Console.ResetColor();
                return true;
            }
            else
            {
                Dye.Inform();
                Console.WriteLine("You have passed this course early");
                Console.ResetColor();
                return false;
            }
        }
        public void UserPassCourse(CourseVM courseVM)
        {
            int rightAnswers = 0;
            Console.WriteLine(string.Join(". ", courseVM.Name, courseVM.Description));

            foreach (var question in courseVM.Test.Questions)
            {
                Dye.Succsess();
                Console.WriteLine(question.Name);
                Console.ResetColor();
                Console.WriteLine("Choose the variant");
                foreach (var answers in question.Answers)
                {
                    Console.WriteLine(answers.Name);
                }
                var userVariatnt = Console.ReadLine().Trim().Split("")[0];
                testController.AnswersCounting(question, userVariatnt, ref rightAnswers);
            }
            if (userService.IsCoursePassed(mapper.CourseVmToDomain(courseVM), rightAnswers))
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
