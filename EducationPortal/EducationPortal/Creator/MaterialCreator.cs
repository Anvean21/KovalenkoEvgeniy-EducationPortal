using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Creator
{
    public class MaterialCreator
    {
        readonly IMaterialService materialService;
        public MaterialCreator(IMaterialService materialService)
        {
            this.materialService = materialService;
        }
        readonly ArticleMaterialValidator acticleValidator = new ArticleMaterialValidator();
        readonly VideoMaterialValidator videoValidator = new VideoMaterialValidator();
        readonly BookMaterialValidator bookValidator = new BookMaterialValidator();

        public ArticleMaterialVM ArticleCreate()
        {
            var articleVM = MaterialHelper.ArticleFullData();
            if (acticleValidator.Validate(articleVM).IsValid)
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
                Console.WriteLine(acticleValidator.Validate(articleVM));
                Console.ResetColor();
                ArticleCreate();
                return null;
            }
        }
        public VideoMaterialVM VideoCreate()
        {
            var videoVM = MaterialHelper.VideoFullData();
            if (videoValidator.Validate(videoVM).IsValid)
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
                Console.WriteLine(videoValidator.Validate(videoVM));
                Console.ResetColor();
                VideoCreate();
                return null;
            }
        }
        public BookMaterialVM BookCreate()
        {
            var bookVM = MaterialHelper.BookFullData();
            if (bookValidator.Validate(bookVM).IsValid)
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
                Console.WriteLine(bookValidator.Validate(bookVM));
                Console.ResetColor();
                return null;
            }
        }
        public void MaterialList()
        {
            Console.ForegroundColor = ConsoleColor.White;
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
    }
}
