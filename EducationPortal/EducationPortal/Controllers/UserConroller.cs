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
        private readonly IMapper mapper;

        public UserConroller(IUserService userService, IMapper mapper, TestController testController)
        {
            this.userService = userService;
            this.testController = testController;
            this.mapper = mapper;
        }

        public void UserLogOut()
        {
            userService.LogOut();
        }

        public bool AddCourseToUserProgress(CourseVM courseVM)
        {
            if (userService.AddCourseToProgress(mapper.Map<CourseVM,Course>(courseVM)))
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
            //Тут null тест приходит, нужен джоин (инклюды)

            var test = testController.GetTestByName(courseVM.Test.Name);
            Console.WriteLine(string.Join(". ", courseVM.Name, courseVM.Description));

            foreach (var question in test.Questions)
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
            if (userService.IsCoursePassed(mapper.Map<CourseVM,Course>(courseVM), rightAnswers))
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
