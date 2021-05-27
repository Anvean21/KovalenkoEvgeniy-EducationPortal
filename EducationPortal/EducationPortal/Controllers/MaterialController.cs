using EducationPortal.Automapper;
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
        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }
        readonly ArticleMaterialValidator acticleValidator = new ArticleMaterialValidator();
        readonly VideoMaterialValidator videoValidator = new VideoMaterialValidator();
        readonly BookMaterialValidator bookValidator = new BookMaterialValidator();
        readonly MaterialValidator validations = new MaterialValidator();

        readonly MaterialHelper materialHelper = new MaterialHelper();

        public ArticleMaterialVM ArticleCreate()
        {
            var articleVM = materialHelper.ArticleFullData();
            if (validations.Validate(articleVM).IsValid && acticleValidator.Validate(articleVM).IsValid)
            {
                materialService.AddArticleMaterial(Map.MapVmToDomain<ArticleMaterialVM, ArticleMaterial>(articleVM));
                Dye.Succsess();
                Console.WriteLine("You have add article");
                Console.ResetColor();
                return articleVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(acticleValidator.Validate(articleVM) + " " + " " + validations.Validate(articleVM));
                Console.ResetColor();
                ArticleCreate();
                return null;
            }
        }
        public VideoMaterialVM VideoCreate()
        {
            var videoVM = materialHelper.VideoFullData();
            if (validations.Validate(videoVM).IsValid && videoValidator.Validate(videoVM).IsValid)
            {
                materialService.AddVideoMaterial(Map.MapVmToDomain<VideoMaterialVM, VideoMaterial>(videoVM));
                Dye.Succsess();
                Console.WriteLine("You have add video");
                Console.ResetColor();
                return videoVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(videoValidator.Validate(videoVM) + " " + " " + validations.Validate(videoVM));
                Console.ResetColor();
                VideoCreate();
                return null;
            }
        }
        public BookMaterialVM BookCreate()
        {
            var bookVM = MaterialHelper.BookFullData();
            if (validations.Validate(bookVM).IsValid && bookValidator.Validate(bookVM).IsValid)
            {
                materialService.AddBookMaterial(Map.MapVmToDomain<BookMaterialVM, BookMaterial>(bookVM));
                Dye.Succsess();
                Console.WriteLine("You have add book");
                Console.ResetColor();
                return bookVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(bookValidator.Validate(bookVM) + " " + " " + validations.Validate(bookVM));
                Console.ResetColor();
                return null;
            }
        }
        public void MaterialList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Book materials");
            Console.WriteLine(string.Join(", ", materialService.GetBookMaterials().Select(x => x.Name)));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Article materials");
            Console.WriteLine(string.Join(", ", materialService.GetArticleMaterials().Select(x => x.Name)));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Video materials");
            Console.WriteLine(string.Join(", ", materialService.GetVideoMaterials().Select(x => x.Name)));

            Console.ResetColor();
        }
        public MaterialVM AddMaterialByName(string name)
        {
            return Map.MapVmToDomain<Material, MaterialVM>(materialService.GetMaterialByName(name));
        }
        public VideoMaterialVM GetVideoMaterialByName(string name)
        {
            return Map.MapVmToDomain<VideoMaterial, VideoMaterialVM>(materialService.GetVideoMaterialByName(name));
        }
        public BookMaterialVM GetBookMaterialByName(string name)
        {
            return Map.MapVmToDomain<BookMaterial, BookMaterialVM>(materialService.GetBookMaterialByName(name));
        }
        public ArticleMaterialVM GetArticleMaterialByName(string name)
        {
            return Map.MapVmToDomain<ArticleMaterial, ArticleMaterialVM>(materialService.GetArticleMaterialByName(name));
        }
    }
}
