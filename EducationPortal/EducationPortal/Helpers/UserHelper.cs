using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public static class UserHelper
    {
        public static UserVM UserFullData()
        {
            UserVM userVM = new UserVM();
            Console.WriteLine("Enter your Name");
            userVM.Name = Console.ReadLine();
            Console.WriteLine("Enter your Email");
            userVM.Email = Console.ReadLine().ToLower();
            Console.WriteLine("Enter your Password");
            userVM.Password = Console.ReadLine();

            return userVM;
        }
        public static (string, string) UserLoginData()
        {
            var turple = (string.Empty, string.Empty);
            Console.WriteLine("Enter your Email");
            turple.Item1 = Console.ReadLine();
            Console.WriteLine("Enter your Password");
            turple.Item2 = Console.ReadLine();

            return turple;
        }

    }
}
