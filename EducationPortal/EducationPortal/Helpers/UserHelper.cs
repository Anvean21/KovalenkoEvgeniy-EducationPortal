using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Automapper
{
    public class UserHelper
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
        public static (string login, string password) UserLoginData()
        {
            var turple = (login: string.Empty, password: string.Empty);
            Console.WriteLine("Enter your Email");
            turple.login = Console.ReadLine();
            Console.WriteLine("Enter your Password");
            turple.password = Console.ReadLine();

            return turple;
        }
    }
}
