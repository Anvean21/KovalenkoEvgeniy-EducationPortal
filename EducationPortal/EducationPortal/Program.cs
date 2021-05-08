using Autofac;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using System;

namespace EducationPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            EFUnitOfWork unitOfWork = new EFUnitOfWork();
            // Create your builder.
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();

            IContainer container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {

                var users = unitOfWork.Users.GetAll();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.UserName}, {user.Role.Name}");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
