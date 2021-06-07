using EducationPortal.Creator;
using EducationPortal.FluentValidationModels;
using EducationPortal.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Helpers
{
    public class TestHelper
    {
        readonly static QuestioController questionController = new QuestioController();
        public TestVM TestFullData()
        {
            TestVM testVM = new TestVM();
            Console.WriteLine("Enter test Name");
            testVM.Name = Console.ReadLine();
            testVM.Questions = new List<QuestionVM>();

            bool infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add question\n2 - Finish adding questions");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        var question = questionController.QuestionCreate();
                        testVM.Questions.Add(question);
                        break;
                    case "2":
                        if (testVM.Questions.Count() >= 4)
                        {
                            return testVM;
                        }
                        Dye.Fail();
                        Console.WriteLine("Count of questions must be greater than 3");
                        Console.ResetColor();
                        break;
                    default:
                        continue;
                }
            }
            return null;
        }
    }
}
