using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EducationPortal.Helpers
{
    public class MaterialHelper
    {
        public VideoMaterialVM VideoFullData()
        {
            VideoMaterialVM videoMaterialVM = new VideoMaterialVM();
            Console.WriteLine("Enter video Name");
            videoMaterialVM.Name = Console.ReadLine();
            Console.WriteLine("Enter video Duration (hh,mm)");
            videoMaterialVM.Duration = Console.ReadLine();
            Console.WriteLine("Chose video quality\n1 - High\n2 - Medium\n3 - Low");

            videoMaterialVM.Quality = (Console.ReadLine()) switch
            {
                "1" => VideoQualityVM.High,
                "2" => VideoQualityVM.Medium,
                "3" => VideoQualityVM.Low,
                _ => VideoQualityVM.Medium,
            };
            return videoMaterialVM;
        }
        public ArticleMaterialVM ArticleFullData()
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
        public BookMaterialVM BookFullData()
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
            bookMaterialVM.Format = (Console.ReadLine()) switch
            {
                "1" => BookFormatVM.Large,
                "2" => BookFormatVM.Medium,
                "3" => BookFormatVM.Small,
                _ => BookFormatVM.Medium,
            };
            return bookMaterialVM;
        }
        public void VideoMaterials(List<VideoMaterialVM> videos)
        {
            foreach (var video in videos)
            {
                Console.WriteLine($"Video: {video.Name}. Quality: {video.Quality}, Duration: {video.Duration}");
            }
        }
        public void ArticleMaterials(List<ArticleMaterialVM> articles)
        {
            foreach (var article in articles)
            {
                Console.WriteLine($"Article - {article.Name}, PublishDate: {article.PublishDate.ToShortDateString()}, Resource: {article.Resource}");
            }
        }
        public void BookMaterials(List<BookMaterialVM> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Book: {book.Name}. Author: {book.Author}, Pages: {book.Pages}, Year: {book.YearOfPublish}. Format: {book.Format}");
            }
        }
    }
}
