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
using System.Text;

namespace EducationPortal.Creator
{
    public class MaterialCreator
    {
        private static readonly IMaterialService materialService = CustomServiceProvider.Provider.GetRequiredService<IMaterialService>();
        static ArticleMaterialValidator acticleValidator = new ArticleMaterialValidator();
        static VideoMaterialValidator videoValidator = new VideoMaterialValidator();
        static BookMaterialValidator bookValidator = new BookMaterialValidator();

        public static ArticleMaterialVM ArticleCreate()
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
        public static VideoMaterialVM VideoCreate()
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
        public static BookMaterialVM BookCreate()
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
        public static void MaterialList()
        {
            foreach (var material in materialService.GetMaterials())
            {
                Console.Write(material.Name + " , ");
            }
        }
        public static MaterialVM AddMaterialByName(string name)
        {
            return Map.MapVmToDomain<Material, MaterialVM>(materialService.GetMaterialByName(name));
        }
    }
}
