using Autofac;
using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Autofac
{
    public class DependecyIngection
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection().AddSingleton(typeof(IRepository<>), typeof(JsonRepository<>))
                .AddTransient<IUserService, UserService>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
