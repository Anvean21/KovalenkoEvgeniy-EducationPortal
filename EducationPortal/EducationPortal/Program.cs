using Autofac;
using EducationPortal.Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using System;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Для запуска из коробки расскоментируйте строку снизу, и перейдите в класс JsonFileOperations
            //EducationContext db = new EducationContext();

            AutofacConfigure.ConfigureContainer();
            UserController userController = new UserController();
            while (true)
            {
                Console.WriteLine("1 - Зарегистрироваться\n2 - Вывести всех пользователей\n3 - Очистить консоль ");
                switch (Console.ReadLine())
                {
                    case "1":
                        User user = new User();
                        Console.WriteLine("Введите имя пользователя");
                        user.UserName = Console.ReadLine();
                        Console.WriteLine("Введите Email");
                        user.Email = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        user.Password = Console.ReadLine();
                        userController.Register(user);
                        break;
                    case "2":
                        userController.UserList();
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
