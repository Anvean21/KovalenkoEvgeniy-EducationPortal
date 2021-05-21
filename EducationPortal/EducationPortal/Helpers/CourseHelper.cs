using EducationPortal.Creator;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
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
            //Убрать это или придумать базовую инициализацию
            courseVM.Materials = new List<MaterialVM>();
            courseVM.Skills = new List<SkillVM>();
            bool infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add video material\n2 - Add book material\n3 - Add article material\n 4 - Select existing material\n5 - Finish adding materials");
                switch (Console.ReadLine())
                {
                    case "1":
                        var videoMaterial = MaterialCreator.VideoCreate();
                        courseVM.Materials.Add(videoMaterial);
                        break;
                    case "2":

                        courseVM.Materials.Add(MaterialCreator.BookCreate());
                        break;
                    case "3":
                        courseVM.Materials.Add(MaterialCreator.ArticleCreate());
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("List existing materials");
                        MaterialCreator.MaterialList();
                        Console.WriteLine("Enter the name of existing material");
                        var name = Console.ReadLine();
                        courseVM.Materials.Add(MaterialCreator.AddMaterialByName(name));
                        Console.Clear();
                        Console.WriteLine("Material added successfully");
                        break;
                    case "5":
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
                        courseVM.Skills.Add(skill);
                        Console.Clear();
                        Console.WriteLine("Skill created and added successfully");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List existing skills");
                        SkillCreator.SkillsList();
                        Console.WriteLine("Enter the name of existing skill");
                        var name = Console.ReadLine();
                        var addSkill = SkillCreator.AddSkillByName(name);
                        courseVM.Skills.Add(addSkill);
                        Console.Clear();
                        Console.WriteLine("Skill added successfully");
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
