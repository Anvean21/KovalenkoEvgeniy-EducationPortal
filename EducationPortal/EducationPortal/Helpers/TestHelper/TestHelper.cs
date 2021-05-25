using EducationPortal.Creator;
using EducationPortal.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Helpers
{
    public class TestHelper
    {
        readonly static QuestionCreator questionCreator = new QuestionCreator();
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
                        var question = questionCreator.QuestionCreate();
                        testVM.Questions.Add(question);
                        break;
                    case "2":
                        infinity = false;
                        break;
                    default:
                        continue;
                }
            }
            return testVM;
        }
    }
}
