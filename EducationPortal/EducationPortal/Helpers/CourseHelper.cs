using EducationPortal.Creator;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Helpers
{
    public static class CourseHelper
    {
        public static CourseVM CourseFullData()
        {
            CourseVM courseVM = new CourseVM();
            Console.WriteLine("Enter course Name");
            courseVM.Name = Console.ReadLine();
            Console.WriteLine("Enter course Description");
            courseVM.Description = Console.ReadLine();
            courseVM.Materials = null;
            while (true)
            {
                Console.WriteLine("1 - Add video material\n2 - Add book material\n3 - Add article material\n 4 - Finish adding materials");
                switch (Console.ReadLine())
                {
                    case "1":
                        courseVM.Materials.Add(MaterialCreator.VideoCreate());
                        break;
                    case "2":

                        courseVM.Materials.Add(MaterialCreator.BookCreate()); 
                        break;
                    case "3":
                        courseVM.Materials.Add(MaterialCreator.ArticleCreate());
                        break;
                    case "4":
                        continue;
                            break;
                    default:
                        continue;
                        break;
                }
            }
            while (true)
            {
                Console.WriteLine("1 - Add new skill\n2 - Select existing\n3 - Finish adding skills");
                Console.WriteLine("List existing skills");
                SkillCreator.SkillsList();
                switch (Console.ReadLine())
                {
                    case "1":
                        courseVM.Skills.Add(SkillCreator.SkillCreate());
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter the name of existing skill");
                        var name = Console.ReadLine();
                        courseVM.Skills.Add(SkillCreator.AddSkillByName(name));
                        break;
                    case "3":
                        return courseVM;
                    default:
                        return courseVM;
                        break;
                }
            }

        }
    }
}
