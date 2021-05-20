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
    public static class MaterialCreator
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
                Console.Clear();
                Console.WriteLine("You have add article");
                return articleVM;
            }
            else
            {
                acticleValidator.ValidateAndThrow(articleVM);
                return null;
            }
        }
        public static VideoMaterialVM VideoCreate()
        {
            var videoVM = MaterialHelper.VideoFullData();
            if (videoValidator.Validate(videoVM).IsValid)
            {
                materialService.AddVideoMaterial(Map.MapVmToDomain<VideoMaterialVM, VideoMaterial>(videoVM));
                Console.Clear();
                Console.WriteLine("You have add video");
                return videoVM;
            }
            else
            {
                videoValidator.ValidateAndThrow(videoVM);
                return null;
            }
        }
        public static BookMaterialVM BookCreate()
        {
            var bookVM = MaterialHelper.BookFullData();
            if (bookValidator.Validate(bookVM).IsValid)
            {
                materialService.AddBookMaterial(Map.MapVmToDomain<BookMaterialVM, BookMaterial>(bookVM));
                Console.Clear();
                Console.WriteLine("You have add book");
                return bookVM;
            }
            else
            {
                bookValidator.ValidateAndThrow(bookVM);
                return null;
            }
        }
    }
}
