using EducationPortal.ViewModels.TestViewModels;
using System;

namespace EducationPortal.Helpers
{
    public class AnswerHelper
    {
        public AnswerVM AnswerData(int variantCount)
        {
            AnswerVM answerVM = new AnswerVM();
            Console.WriteLine("Enter answer Name");
            answerVM.Name = answerVM.Variant[variantCount] + ". " + Console.ReadLine();
            Console.WriteLine("Is it true answer?\n Y/N");
            string isTrue = Console.ReadLine().ToUpper();
            answerVM.IsTrue = (isTrue == "Y");

            return answerVM; 
        }
    }
}
