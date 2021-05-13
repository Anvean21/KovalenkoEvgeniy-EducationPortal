using Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
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
            //Непонятно как делать DI c обобщенными классами Встроенный контейнер имеет только asp.net core, тут его нету:(
            builder.RegisterType<JsonRepository<User>>().As(typeof(IRepository<User>));
            builder.RegisterType<UserService>().As(typeof(IUserService));

            var container = builder.Build();

        }
    }
}
