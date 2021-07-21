﻿// <auto-generated />
using System;
using EducationPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EducationPortal.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EducationContext))]
    [Migration("20210627132111_VideoMaterial")]
    partial class VideoMaterial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseMaterial", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("CourseMaterial");
                });

            modelBuilder.Entity("CourseSkill", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CourseSkill");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsTrue")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserCoursesInProgress", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCoursesInProgress");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserPassedCourses", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserPassedCourses");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserSkills", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = ".Net"
                        });
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.ArticleMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Domain.Core.Material");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Resource")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.ToTable("ArticleMaterial");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Article 1",
                            PublishDate = new DateTime(2021, 6, 27, 16, 21, 10, 678, DateTimeKind.Local).AddTicks(5274),
                            Resource = "Metanit.com"
                        });
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.BookMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Domain.Core.Material");

                    b.Property<string>("Author")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<int>("YearOfPublish")
                        .HasColumnType("int");

                    b.ToTable("BookMaterial");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "CLR via C#",
                            Author = "Richetr",
                            Format = 2,
                            Pages = 236,
                            YearOfPublish = 2006
                        });
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.VideoMaterial", b =>
                {
                    b.HasBaseType("EducationPortal.Domain.Core.Material");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.ToTable("VideoMaterial");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Extreme Code",
                            Duration = "19,27",
                            Quality = 2
                        });
                });

            modelBuilder.Entity("CourseMaterial", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationPortal.Domain.Core.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseSkill", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationPortal.Domain.Core.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Course", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Entities.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Answer", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Entities.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Question", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Entities.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserCoursesInProgress", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Course", "Course")
                        .WithMany("UsersInProgress")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationPortal.Domain.Core.User", "User")
                        .WithMany("CoursesInProgress")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserPassedCourses", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Course", "Course")
                        .WithMany("UsersPassed")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EducationPortal.Domain.Core.User", "User")
                        .WithMany("PassedCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.RelationModels.UserSkills", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationPortal.Domain.Core.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.ArticleMaterial", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Material", null)
                        .WithOne()
                        .HasForeignKey("EducationPortal.Domain.Core.ArticleMaterial", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.BookMaterial", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Material", null)
                        .WithOne()
                        .HasForeignKey("EducationPortal.Domain.Core.BookMaterial", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.VideoMaterial", b =>
                {
                    b.HasOne("EducationPortal.Domain.Core.Material", null)
                        .WithOne()
                        .HasForeignKey("EducationPortal.Domain.Core.VideoMaterial", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Course", b =>
                {
                    b.Navigation("UsersInProgress");

                    b.Navigation("UsersPassed");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Entities.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.Skill", b =>
                {
                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("EducationPortal.Domain.Core.User", b =>
                {
                    b.Navigation("CoursesInProgress");

                    b.Navigation("PassedCourses");

                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}