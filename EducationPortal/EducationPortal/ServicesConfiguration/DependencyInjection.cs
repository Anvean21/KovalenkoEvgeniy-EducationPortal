using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EducationPortal.DependencyInjection
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
