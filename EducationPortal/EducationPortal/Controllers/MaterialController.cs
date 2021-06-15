using EducationPortal.Automapper;
using EducationPortal.Controllers;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;
using System.Linq;

namespace EducationPortal.Creator
{
    public class MaterialController
    {
        readonly IMaterialService materialService;
        readonly VideoMaterialController videoMaterialController;
        readonly ArticleMaterialController articleMaterialController;
        readonly BookMaterialController bookMaterialController;

        private readonly Map mapper = new Map();

        public MaterialController(IMaterialService materialService, VideoMaterialController videoMaterialController, ArticleMaterialController articleMaterialController, BookMaterialController bookMaterialController)
        {
            this.materialService = materialService;
            this.videoMaterialController = videoMaterialController;
            this.articleMaterialController = articleMaterialController;
            this.bookMaterialController = bookMaterialController;
        }

        public void MaterialList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Book materials");
            var books = bookMaterialController.GetBookMaterials().Select(x => x.Name);
            Console.WriteLine(string.Join(", ", books));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Article materials");
            Console.WriteLine(string.Join(", ", articleMaterialController.GetArticleMaterials().Select(x => x.Name)));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Video materials");
            Console.WriteLine(string.Join(", ", videoMaterialController.GetVideoMaterials().Select(x => x.Name)));

            Console.ResetColor();
        }

        public MaterialVM AddMaterialByName(string name)
        {
            return mapper.MapVmToDomain<Material, MaterialVM>(materialService.GetMaterialByName(name));
        }
    }
}
