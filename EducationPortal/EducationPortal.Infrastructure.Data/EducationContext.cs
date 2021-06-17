using EducationPortal.Domain.Core;
using EducationPortal.Domain.Core.Entities;
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

        public EducationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
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

            //modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Anvean", Email = "anvean@gmail.com", Password = "leitxrf33" });

            //modelBuilder.Entity<Skill>().HasData(new Skill { Name = "C#", Id = 1 });

            //modelBuilder.Entity<ArticleMaterial>().HasData(new ArticleMaterial { Id = 1, Name = "Article 1", PublishDate = DateTime.Now, Resource = "Metanit.com" });

            //modelBuilder.Entity<VideoMaterial>().HasData(new VideoMaterial { Id = 2, Name = "Extreme Code", Quality = VideoQuality.High, Duration = "19,27" });

            //modelBuilder.Entity<BookMaterial>().HasData(new BookMaterial { Id = 3, Name = "CLR via C#", Author = "Richetr", Format = BookFormat.Large, Pages = 236, YearOfPublish = 2006 });

            //modelBuilder.Entity<Answer>().HasData(new Answer[]{
            //new Answer { Id = 1, Name = "answer 1", IsTrue = true, Variant = "a".ToCharArray()},
            //new Answer { Id = 2, Name = "answer 2", IsTrue = false, Variant = "b".ToCharArray()}
            // });

            //modelBuilder.Entity<Question>().HasData(new Question { Id = 1, Name = "Question 1" });

            //modelBuilder.Entity<Test>().HasData(new Test { Id = 1, Name = "Test1", CourseId = 1 });

            //modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Course", Description = "Description" });
        }
    }
}
