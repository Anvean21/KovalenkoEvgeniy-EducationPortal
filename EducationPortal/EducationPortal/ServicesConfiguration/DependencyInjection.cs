using EducationPortal.Command;
using EducationPortal.Command.Commands;
using EducationPortal.Command.Interfaces;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace EducationPortal.DependencyInjection
{
    public class DependecyInjection
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddScoped(typeof(IRepository<>), typeof(JsonRepository<>))
                .AddTransient<IUserService, UserService>()
                .AddTransient<ISkillService, SkillService>()
                .AddTransient<IMaterialService, MaterialService>()
                .AddTransient<ICourseService, CourseService>()
                .AddTransient<ITestService, TestService>()
                .AddTransient<IVideoMaterialService, VideoMaterialService>()
                .AddTransient<IBookMaterialService, BookMaterialService>()
                .AddTransient<IArticleMaterialService, ArticleMaterialService>()
                .AddSingleton<ICommandProcessor, CommandProcessor>()
                .AddTransient<ICommand, RegisterCommand>()
                .AddTransient<ICommand, LogInCommand>()
                .AddTransient<IAuthCommand, AddCourseCommand>()
                .AddTransient<IAuthCommand, PassCourseCommand>()
                .AddTransient<IAuthCommand, LogOutCommand>()
                .BuildServiceProvider(new ServiceProviderOptions());
            return provider;
        }
    }
}
