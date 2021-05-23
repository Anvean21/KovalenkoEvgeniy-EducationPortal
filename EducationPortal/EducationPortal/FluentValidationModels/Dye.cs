using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.FluentValidationModels
{
    public static class Dye
    {
        public static void Succsess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void Fail()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
