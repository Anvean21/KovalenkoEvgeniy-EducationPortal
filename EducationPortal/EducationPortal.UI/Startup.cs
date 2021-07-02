using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Infrastructure.Business;
using EducationPortal.Infrastructure.Business.Password_hash;
using EducationPortal.Infrastructure.Data;
using EducationPortal.Services.Interfaces;
using EducationPortal.UI.Automapper;
using EducationPortal.UI.FluentValidation;
using EducationPortal.UI.Models;
using EducationPortal.UI.Models.TestViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EducationPortal.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                });


            services
                .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
                .AddScoped<DbContext, EducationContext>()
                .AddScoped<IPasswordHasher, MD5PasswordHasher>()
                .AddAutoMapper(cfg => cfg.AddProfile<MainProfile>())
                .AddScoped<IMapper, EntityMapper>()
                .AddScoped<IUserService, UserService>()
                .AddTransient<ISkillService, SkillService>()
                .AddTransient<IMaterialService, MaterialService>()
                .AddTransient<ICourseService, CourseService>()
                .AddTransient<ICourseTestService, CourseTestService>()
                .AddTransient<IVideoMaterialService, VideoMaterialService>()
                .AddTransient<IBookMaterialService, BookMaterialService>()
                .AddTransient<IArticleMaterialService, ArticleMaterialService>()
                .AddFluentValidation()
                .AddTransient<IValidator<UserVM>, FluentUserValidator>()
                .AddTransient<IValidator<CourseVM>, FluentCourseValidator>()
                .AddTransient<IValidator<VideoMaterialVM>, FluentVideoMaterialValidator>()
                .AddTransient<IValidator<ArticleMaterialVM>, FluentArticleMaterialValidator>()
                .AddTransient<IValidator<BookMaterialVM>, FluentBookMaterialValidator>()
                .AddTransient<IValidator<SkillVM>, FluentSkillValidator>()
                .AddTransient<IValidator<TestVM>, FluentTestValidator>()
                .AddTransient<IValidator<QuestionVM>, FluentQuestionValidator>()
                .AddTransient<IValidator<AnswerVM>, FluentAnswerValidator>()
                .AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
