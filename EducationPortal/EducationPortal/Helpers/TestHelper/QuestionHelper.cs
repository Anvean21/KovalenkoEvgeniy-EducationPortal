using EducationPortal.FluentValidationModels;
using EducationPortal.ViewModels.TestViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Helpers
{
    public class QuestionHelper
    {
        readonly AnswerHelper answerHelper = new AnswerHelper();
        public QuestionVM QuestionData()
        {
            QuestionVM questionVM = new QuestionVM();
            Console.WriteLine("Enter question");
            questionVM.Name = Console.ReadLine();
            questionVM.Answers = new List<AnswerVM>();

            bool infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add answer\n2 - Finish adding questions");
                switch (Console.ReadLine())
                {
                    case "1":
                        Dye.Succsess();
                        Console.WriteLine(questionVM.Name);
                        Console.ResetColor();
                        var answer = answerHelper.AnswerData();
                        if (questionVM.Answers.Count(x => x.IsTrue == true) == 1 && answer.IsTrue == true)
                        {
                            Dye.Fail();
                            Console.WriteLine(new Exception("True answer alredy exist!"));
                            Console.ResetColor();
                            break;
                        }
                        Dye.Succsess();
                        Console.WriteLine("Answer added");
                        Console.ResetColor();
                        questionVM.Answers.Add(answer);
                        break;
                    case "2":
                        infinity = false;
                        break;
                    default:
                        continue;
                }
            }
            if (questionVM.Answers.Any(x => x.IsTrue == true) && questionVM.Answers.Count() >=4 && questionVM.Answers.Count() <= 8)
            {
                return questionVM;
            }
            Console.WriteLine(new Exception("Atleast 1 answer must be true. Min. 4 answers. Max. 8 answers"));
            QuestionData();
            return null;
        }
    }

}
