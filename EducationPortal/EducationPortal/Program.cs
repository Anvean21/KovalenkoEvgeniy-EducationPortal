using Autofac;
using EducationPortal.Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using System;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService user1 = new UserService(new JsonSet<User>());
            AutofacConfigure.ConfigureContainer();
            
            while (true)
            {
                Console.WriteLine("1 - Зарегистрироваться\n2 - Вывести всех пользователей\n3 - Очистить консоль ");
                switch (Console.ReadLine())
                {
                    case "1":
                        User user = new User();
                        Console.WriteLine("Введите имя пользователя");
                        user.Name = Console.ReadLine();
                        Console.WriteLine("Введите Email");
                        user.Email = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        user.Password = Console.ReadLine();
                        user1.Register(user);
                        break;
                    case "2":
                        user1.UserList();
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
