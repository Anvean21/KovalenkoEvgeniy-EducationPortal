using EducationPortal.Automapper;
using EducationPortal.Controllers;
using EducationPortal.Creator;
using EducationPortal.FluentValidationModels;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Helpers
{
    public class CourseHelper
    {
        readonly static VideoMaterialController videoMaterialController = new VideoMaterialController(CustomServiceProvider.Provider.GetRequiredService<IVideoMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly static ArticleMaterialController articleMaterialController = new ArticleMaterialController(CustomServiceProvider.Provider.GetRequiredService<IArticleMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly static BookMaterialController bookMaterialController = new BookMaterialController(CustomServiceProvider.Provider.GetRequiredService<IBookMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        private readonly MaterialController materialController = new MaterialController(CustomServiceProvider.Provider.GetRequiredService<IMaterialService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly SkillConroller skillController = new SkillConroller(CustomServiceProvider.Provider.GetRequiredService<ISkillService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

        readonly TestController testController = new TestController(CustomServiceProvider.Provider.GetRequiredService<ICourseTestService>(), CustomServiceProvider.Provider.GetRequiredService<IMapper>());

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
                        videoMaterialController.VideoCreate();
                        break;
                    case "2":
                        bookMaterialController.BookCreate();
                        break;
                    case "3":
                        articleMaterialController.ArticleCreate();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("List existing materials");
                        materialController.MaterialList();
                        Console.WriteLine("\nEnter Id of existing material");
                        var Id = int.Parse(Console.ReadLine());

                        if (courseVM.Materials.Any(x => x.Id == Id))
                        {
                            Dye.Fail();
                            Console.WriteLine("Material already exists in course");
                            Console.ResetColor();
                        }
                        else
                        {
                            var materialVM = materialController.AddMaterialById(Id);

                            if (materialVM == null)
                            {
                                Dye.Fail();
                                Console.WriteLine("Invalid material Id");
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
                        var skill = skillController.SkillCreate();
                        Dye.Succsess();
                        Console.WriteLine("Skill created successfully, now you can add it to your course");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List existing skills: ");
                        skillController.SkillsList();
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
                            var skillVM = skillController.AddSkillByName(name);
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
            //Айдишник теста равен нулю
            var test = testController.TestCreate();
            var mappedTest = testController.GetTestByName(test.Name);

            courseVM.Test = mappedTest;
            courseVM.TestId = mappedTest.Id;

            return courseVM;
        }
    }
}
