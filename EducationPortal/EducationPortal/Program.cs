using Autofac;
using AutoMapper;
using EducationPortal.Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.FluentValidationModels;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using System;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService(new JsonRepository<User>());
            UserValidator validator = new UserValidator();
            DependecyIngection.ConfigureService();
            
            while (true)
            {
                Console.WriteLine("1 - Зарегистрироваться\n2 - Войти в систему\n3 - Вывести всех пользователей\n4 - Очистить консоль ");
                switch (Console.ReadLine())
                {
                    case "1":
                        UserVM userVM = new UserVM();
                        Console.WriteLine("Введите имя пользователя");
                        userVM.Name = Console.ReadLine();
                        Console.WriteLine("Введите Email");
                        userVM.Email = Console.ReadLine().ToLower();
                        Console.WriteLine("Введите пароль");
                        userVM.Password = Console.ReadLine();

                        if (validator.Validate(userVM).IsValid)
                        {
                            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<UserVM, User>());
                            var mapper = new Mapper(configuration);
                            var user = mapper.Map<UserVM, User>(userVM);
                            userService.Register(user);
                        }
                        else
                            validator.ValidateAndThrow(userVM);
                        break;
                    case "2":
                        Console.WriteLine("Введите ваш email");
                        var name = Console.ReadLine();
                        Console.WriteLine("Введите ваш пароль");
                        var password = Console.ReadLine();
                        if (userService.LogIn(name,password))
                        {
                            Console.WriteLine("Вы успешно вошли в систему");
                        }
                        else
                        {
                            Console.WriteLine("Пользователь не найден");
                        }
                        break;
                    case "3":
                        foreach (var item in userService.UsersList())
                        {
                            Console.WriteLine($"Name: {item.Name}, Email: {item.Email}, Password: {item.Password}");
                        }
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
