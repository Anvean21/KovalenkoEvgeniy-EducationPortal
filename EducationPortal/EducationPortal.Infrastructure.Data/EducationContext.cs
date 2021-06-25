using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Core.Entities.RelationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EducationPortal.Infrastructure.Data
{
    public class EducationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ArticleMaterial> ArticleMaterials { get; set; }
        public DbSet<VideoMaterial> VideoMaterials { get; set; }
        public DbSet<BookMaterial> BookMaterials { get; set; }

        public EducationContext(DbContextOptions<EducationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleMaterial>().ToTable("ArticleMaterial");
            modelBuilder.Entity<VideoMaterial>().ToTable("VideoMaterial");
            modelBuilder.Entity<BookMaterial>().ToTable("BookMaterial");

            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.Email).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.Password).HasMaxLength(128);

            modelBuilder.Entity<Skill>().Property(s => s.Name).HasMaxLength(30);

            modelBuilder.Entity<Material>().Property(m => m.Name).HasMaxLength(50);

            modelBuilder.Entity<ArticleMaterial>().Property(b => b.Name).HasMaxLength(128);
            modelBuilder.Entity<ArticleMaterial>().Property(b => b.Resource).HasMaxLength(250);

            modelBuilder.Entity<VideoMaterial>().Property(v => v.Name).HasMaxLength(128);

            modelBuilder.Entity<BookMaterial>().Property(v => v.Name).HasMaxLength(128);
            modelBuilder.Entity<BookMaterial>().Property(v => v.Author).HasMaxLength(128);

            modelBuilder.Entity<Test>().Property(c => c.Name).HasMaxLength(30);

            modelBuilder.Entity<Question>().Property(c => c.Name).HasMaxLength(50);

            modelBuilder.Entity<Answer>().Property(c => c.Name).HasMaxLength(50);

            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(128);
            modelBuilder.Entity<Course>().Property(c => c.Description).HasMaxLength(250);

            modelBuilder.Entity<UserSkills>().HasKey(x => new { x.UserId, x.SkillId });
            modelBuilder.Entity<UserSkills>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSkills)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserSkills>()
                .HasOne(x => x.Skill)
                .WithMany(x => x.UserSkills)
                .HasForeignKey(x => x.SkillId);

            modelBuilder.Entity<UserCoursesInProgress>().HasKey(x => new { x.UserId, x.CourseId });
            modelBuilder.Entity<UserCoursesInProgress>()
                .HasOne(x => x.User)
                .WithMany(x => x.CoursesInProgress)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserCoursesInProgress>()
                .HasOne(x => x.Course)
                .WithMany(x => x.UsersInProgress)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserPassedCourses>().HasKey(x => new { x.UserId, x.CourseId });
            modelBuilder.Entity<UserPassedCourses>()
                .HasOne(x => x.User)
                .WithMany(x => x.PassedCourses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserPassedCourses>()
                .HasOne(x => x.Course)
                .WithMany(x => x.UsersPassed)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            var skill = new Skill { Id = 1, Name = "C#" };
            var skill2 = new Skill { Id = 2, Name = ".Net" };
            var skills = new List<Skill>() { skill, skill2 };

            var article = new ArticleMaterial { Id = 1, Name = "Article 1", PublishDate = DateTime.Now, Resource = "Metanit.com" };
            var video = new VideoMaterial { Id = 2, Name = "Extreme Code", Quality = VideoQuality.High, Duration = "19,27" };
            var book = new BookMaterial { Id = 3, Name = "CLR via C#", Author = "Richetr", Format = BookFormat.Large, Pages = 236, YearOfPublish = 2006 };

            modelBuilder.Entity<Skill>().HasData(skills);
            modelBuilder.Entity<ArticleMaterial>().HasData(article);
            modelBuilder.Entity<VideoMaterial>().HasData(video);
            modelBuilder.Entity<BookMaterial>().HasData(book);
        }
    }
}
