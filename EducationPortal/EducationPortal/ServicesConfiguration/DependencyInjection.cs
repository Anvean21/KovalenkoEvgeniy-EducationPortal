using EducationPortal.Automapper;
using EducationPortal.Command;
using EducationPortal.Command.Commands;
using EducationPortal.Command.Interfaces;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Business.Password_hash;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
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
                .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
                .AddTransient<DbContext, EducationContext>()
                .AddScoped<IPasswordHasher, MD5PasswordHasher>()
                .AddAutoMapper(cfg => cfg.AddProfile<MainProfile>())
                .AddScoped<IMapper,EntityMapper>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ISkillService, SkillService>()
                .AddTransient<IMaterialService, MaterialService>()
                .AddTransient<ICourseService, CourseService>()
                .AddTransient<ICourseTestService, CourseTestService>()
                .AddTransient<IVideoMaterialService, VideoMaterialService>()
                .AddTransient<IBookMaterialService, BookMaterialService>()
                .AddTransient<IArticleMaterialService, ArticleMaterialService>()
                .AddScoped<ICommandProcessor, CommandProcessor>()
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
