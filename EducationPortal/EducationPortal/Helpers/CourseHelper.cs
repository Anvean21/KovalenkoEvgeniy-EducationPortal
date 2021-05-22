﻿using EducationPortal.Creator;
using EducationPortal.FluentValidationModels;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Helpers
{
    public class CourseHelper
    {
        public static CourseVM CourseFullData()
        {
            CourseVM courseVM = new CourseVM();
            Console.WriteLine("Enter course Name");
            courseVM.Name = Console.ReadLine();
            Console.WriteLine("Enter course Description");
            courseVM.Description = Console.ReadLine();
            courseVM.Materials = new List<MaterialVM>();
            courseVM.Skills = new List<SkillVM>();
            bool infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add video material\n2 - Add book material\n3 - Add article material\n 4 - Select existing material\n5 - Finish adding materials");
                switch (Console.ReadLine())
                {
                    case "1":
                        MaterialCreator.VideoCreate();
                        break;
                    case "2":
                        MaterialCreator.BookCreate();
                        break;
                    case "3":
                        MaterialCreator.ArticleCreate();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("List existing materials");
                        MaterialCreator.MaterialList();
                        Console.WriteLine("\nEnter the name of existing material");
                        var name = Console.ReadLine().ToLower();
                        if (courseVM.Materials.Any(x => x.Name.ToLower() == name.ToLower()))
                        {
                            Dye.Fail();
                            Console.WriteLine("Invalid name or Material already exists in course");
                            Console.ResetColor();
                        }
                        else
                        {
                            courseVM.Materials.Add(MaterialCreator.AddMaterialByName(name));
                            Dye.Succsess();
                            Console.WriteLine("Material added successfully");
                            Console.ResetColor();
                        }
                        break;
                    case "5":
                        Dye.Succsess();
                        Console.WriteLine("Materials added successfully");
                        Console.ResetColor();
                        infinity = false;
                        break;
                    default:
                        continue;
                }
            }
            while (true)
            {
                Console.WriteLine("1 - Add new skill\n2 - Select existing\n3 - Finish adding skills");

                switch (Console.ReadLine())
                {
                    case "1":
                        var skill = SkillCreator.SkillCreate();
                        Dye.Succsess();
                        Console.WriteLine("Skill created successfully, now you can add it to your course");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List existing skills: ");
                        SkillCreator.SkillsList();
                        Console.WriteLine("\nEnter the name of existing skill");
                        var name = Console.ReadLine().ToLower();
                        if (courseVM.Skills.Any(x => x.Name.ToLower() == name.ToLower()))
                        {
                            Dye.Fail();
                            Console.WriteLine("Invalid name or Skill already exists in course");
                            Console.ResetColor();
                        }
                        else
                        {
                            courseVM.Skills.Add(SkillCreator.AddSkillByName(name));
                            Dye.Succsess();
                            Console.WriteLine("Skill added successfully");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        return courseVM;
                    default:
                        continue;
                }
            }

        }
    }
}
