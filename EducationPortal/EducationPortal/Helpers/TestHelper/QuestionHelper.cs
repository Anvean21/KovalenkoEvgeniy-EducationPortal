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
        public QuestionVM QuestionData(int variant)
        {
            QuestionVM questionVM = new QuestionVM();
            Console.WriteLine("Enter question");
            questionVM.Name = Console.ReadLine();
            questionVM.Answers = new List<AnswerVM>();

            bool infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add answer\n2 - Finish adding answers");
                switch (Console.ReadLine())
                {
                    case "1":
                        Dye.Succsess();
                        Console.WriteLine(questionVM.Name);
                        Console.ResetColor();
                        var answer = answerHelper.AnswerData(variant++);
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

                        //Вставить маппинг ответов
                        questionVM.Answers.Add(answer);
                        break;
                    case "2":
                        if (questionVM.Answers.Any(x => x.IsTrue == true) && questionVM.Answers.Count() >= 2 && questionVM.Answers.Count() <= 6)
                        {
                            return questionVM;
                        }
                        Dye.Fail();
                        Console.WriteLine(new Exception("Atleast 1 answer must be true. Min. 2 answers. Max. 6 answers"));
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
