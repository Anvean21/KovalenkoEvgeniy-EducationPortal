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
            EducationContext db = new EducationContext();
            EFUnitOfWork unitOfWork = new EFUnitOfWork();
            // Create your builder.
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();

            IContainer container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                //JsonFileOperations<User>.JsonDeserializer();
                foreach (var user in unitOfWork.Users.GetAll())
                {
                    Console.WriteLine($"{user.UserName}, {user.Email}");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
