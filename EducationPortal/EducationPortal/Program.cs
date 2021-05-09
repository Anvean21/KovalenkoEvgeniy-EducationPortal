using Autofac;
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
            //Для запуска из коробки перейдите в класс JsonFileOperations
            EducationContext db = new EducationContext();
            EFUnitOfWork unitOfWork = new EFUnitOfWork();
            var builder = new ContainerBuilder();

            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();

            IContainer container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                foreach (var user in unitOfWork.Users.GetAll())
                {
                    Console.WriteLine($"{user.UserName}, {user.Email}");
                }
            }
            Console.WriteLine("+++++");
        }
    }
}
