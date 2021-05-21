using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EducationPortal.Helpers
{
    public static class MaterialHelper
    {
        public static VideoMaterialVM VideoFullData()
        {
            VideoMaterialVM videoMaterialVM = new VideoMaterialVM();
            Console.WriteLine("Enter video Name");
            videoMaterialVM.Name = Console.ReadLine();
            Console.WriteLine("Enter video Duration (00,00)");
            videoMaterialVM.Duration = Console.ReadLine();
            Console.WriteLine("Chose video quality\n1 - High\n2 - Medium\n3 - Low");

            switch (Console.ReadLine())
            {
                case "1":
                    videoMaterialVM.Quality = VideoQualityVM.High;
                    break;
                case "2":
                    videoMaterialVM.Quality = VideoQualityVM.Medium;
                    break;
                case "3":
                    videoMaterialVM.Quality = VideoQualityVM.Low;
                    break;
                default:
                    videoMaterialVM.Quality = VideoQualityVM.Medium;
                    break;
            }
            return videoMaterialVM;
        }
        public static ArticleMaterialVM ArticleFullData()
        {
            ArticleMaterialVM arcticleMaterialVM = new ArticleMaterialVM();
            Console.WriteLine("Enter article Name");
            arcticleMaterialVM.Name = Console.ReadLine();
            Console.WriteLine(@"Enter article site (https:\\article\path.com)");
            arcticleMaterialVM.Resource = Console.ReadLine().ToLower();
            Console.WriteLine("Enter article publish date (yyyy, dd, MM)");
            CultureInfo provider = CultureInfo.InvariantCulture;
            arcticleMaterialVM.PublishDate = DateTime.ParseExact(Console.ReadLine(), "yyyy, dd, MM", provider);

            return arcticleMaterialVM;
        }
        public static BookMaterialVM BookFullData()
        {
            BookMaterialVM bookMaterialVM = new BookMaterialVM();
            Console.WriteLine("Enter book name");
            bookMaterialVM.Name = Console.ReadLine();
            Console.WriteLine("Enter book author");
            bookMaterialVM.Author = Console.ReadLine();
            Console.WriteLine("Enter count of pages");
            bookMaterialVM.Pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter year of publish");
            bookMaterialVM.YearOfPublish = int.Parse(Console.ReadLine());
            Console.WriteLine("Chose book format\n1 - Large\n2 - Medium\n3 - Small");
            switch (Console.ReadLine())
            {
                case "1":
                    bookMaterialVM.Format = BookFormatVM.Large;
                    break;
                case "2":
                    bookMaterialVM.Format = BookFormatVM.Medium;
                    break;
                case "3":
                    bookMaterialVM.Format = BookFormatVM.Small;
                    break;
                default:
                    bookMaterialVM.Format = BookFormatVM.Medium;
                    break;
            }
            return bookMaterialVM;
        }
    }
}
