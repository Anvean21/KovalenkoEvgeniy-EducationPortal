using EducationPortal.Creator;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Helpers
{
    public class CourseHelper
    {
        readonly MaterialCreator materialCreator = new MaterialCreator(CustomServiceProvider.Provider.GetRequiredService<IMaterialService>());

        readonly SkillCreator skillCreator = new SkillCreator(CustomServiceProvider.Provider.GetRequiredService<ISkillService>());

        readonly TestCreator testCreator = new TestCreator(CustomServiceProvider.Provider.GetRequiredService<ITestService>());

        public CourseVM CourseFullData()
        {
            var courseVM = new CourseVM();
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
                        materialCreator.VideoCreate();
                        break;
                    case "2":
                        materialCreator.BookCreate();
                        break;
                    case "3":
                        materialCreator.ArticleCreate();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("List existing materials");
                        materialCreator.MaterialList();
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
                            var materialVM = materialCreator.AddMaterialByName(name);
                            if (materialVM == null)
                            {
                                Dye.Fail();
                                Console.WriteLine("Invalid material name");
                                Console.ResetColor();
                                break;
                            }
                            courseVM.Materials.Add(materialVM);
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
            infinity = true;
            while (infinity)
            {
                Console.WriteLine("1 - Add new skill\n2 - Select existing\n3 - Finish adding skills");

                switch (Console.ReadLine())
                {
                    case "1":
                        var skill = skillCreator.SkillCreate();
                        Dye.Succsess();
                        Console.WriteLine("Skill created successfully, now you can add it to your course");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List existing skills: ");
                        skillCreator.SkillsList();
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
                            var skillVM = skillCreator.AddSkillByName(name);
                            if (skillVM == null)
                            {
                                Dye.Fail();
                                Console.WriteLine("Invalid skill name");
                                Console.ResetColor();
                                break;
                            }
                            courseVM.Skills.Add(skillVM);
                            Dye.Succsess();
                            Console.WriteLine("Skill added successfully");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        Dye.Succsess();
                        Console.WriteLine("Skills added successfully");
                        Console.ResetColor();
                        infinity = false;
                        break;
                    default:
                        continue;
                }
            }
            courseVM.TestVM = testCreator.TestCreate();
            return courseVM;
        }
    }
}
