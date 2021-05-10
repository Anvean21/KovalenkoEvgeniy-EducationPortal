using Autofac;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Autofac
{
   public class AutofacConfigure
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();

            var container = builder.Build();

        }
    }
}
