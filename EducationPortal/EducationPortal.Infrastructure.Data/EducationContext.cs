using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
using EducationPortal.Domain.Core.Entities.RelationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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

        public EducationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EducationPortal;Trusted_Connection=True;")
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleMaterial>().ToTable("ArticleMaterial");
            modelBuilder.Entity<VideoMaterial>().ToTable("VideoMaterial");
            modelBuilder.Entity<BookMaterial>().ToTable("BookMaterial");

            modelBuilder.Entity<Material>().HasKey(x => x.Id);

            modelBuilder.Entity<Test>().HasOne(x => x.Course).WithOne(x => x.Test).HasForeignKey<Course>(x => x.TestId);

            modelBuilder.Entity<UserSkills>().HasKey(x => new { x.UserId, x.SkillId });
            modelBuilder.Entity<UserSkills>().HasOne(x => x.User).WithMany(x => x.UserSkills).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserSkills>().HasOne(x => x.Skill).WithMany(x => x.UserSkills).HasForeignKey(x => x.SkillId);

            modelBuilder.Entity<UserCoursesInProgress>().HasKey(x => new { x.UserId, x.CourseId });

            modelBuilder.Entity<UserCoursesInProgress>()
                .HasOne(x => x.User)
                .WithMany(x => x.CourseInProgress)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCoursesInProgress>()
                .HasOne(x => x.Course)
                .WithMany(x => x.UsersInProgresses)
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
                .WithMany(x => x.PassedCourses)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
