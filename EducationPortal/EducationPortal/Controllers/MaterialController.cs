using EducationPortal.Automapper;
using EducationPortal.Controllers;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Creator
{
    public class MaterialController
    {
        readonly IMaterialService materialService;
        private readonly IMapper mapper;

        public MaterialController(IMaterialService materialService, IMapper mapper)
        {
            this.materialService = materialService;
            this.mapper = mapper;
        }

        public void MaterialList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Book materials");
            Console.WriteLine(string.Join("\n", mapper.Map<Material, MaterialVM>(materialService.GetBookMaterials()).Select(x => $"Id - {x.Id}, Name - {x.Name} ")));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Article materials");
            Console.WriteLine(string.Join("\n", mapper.Map<Material, MaterialVM>(materialService.GetArticleMaterials()).Select(x => $"Id - {x.Id}, Name - {x.Name} ")));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Video materials");
            Console.WriteLine(string.Join("\n", mapper.Map<Material, MaterialVM>(materialService.GetVideoMaterials()).Select(x => $"Id - {x.Id}, Name - {x.Name} ")));

            Console.ResetColor();
        }

        public MaterialVM AddMaterialById(int Id)
        {
            return mapper.Map<Material, MaterialVM>(materialService.GetMaterialById(Id));
        }
    }
}
