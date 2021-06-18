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

            var books = materialService.GetBookMaterials();
            var mappedBooksVM = mapper.Map<Material, MaterialVM>(books);

            Console.WriteLine(string.Join("\n", mappedBooksVM.Select(x => $"Id - {x.Id}, Name - {x.Name} ")));

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Article materials");
            var articles = materialService.GetArticleMaterials();
            var mappedArticlesVM = mapper.Map<Material, MaterialVM>(articles);

            Console.WriteLine(string.Join("\n", mappedArticlesVM.Select(x => $"Id - {x.Id}, Name - {x.Name} ")));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Video materials");

            var videos = materialService.GetVideoMaterials();
            var mappedVideosVM = mapper.Map<Material, MaterialVM>(videos);

            Console.WriteLine(string.Join("\n", mappedVideosVM.Select(x => $"Id - {x.Id}, Name - {x.Name} ")));;

            Console.ResetColor();
        }

        public MaterialVM AddMaterialById(int Id)
        {
            var materialById = materialService.GetMaterialById(Id);
            var mappedMaterial = mapper.Map<Material, MaterialVM>(materialById);
            return mappedMaterial;
        }
    }
}
