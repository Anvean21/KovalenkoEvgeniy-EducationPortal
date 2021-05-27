using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<BookMaterial> bookMaterialRepository;
        private readonly IRepository<ArticleMaterial> articleMaterialRepository;
        private readonly IRepository<VideoMaterial> videoMaterialRepository;
        public MaterialService(IRepository<BookMaterial> bookMaterialRepository, IRepository<ArticleMaterial> articleMaterialRepository, IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.bookMaterialRepository = bookMaterialRepository;
            this.articleMaterialRepository = articleMaterialRepository;
            this.videoMaterialRepository = videoMaterialRepository;
        }

        public void AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            articleMaterialRepository.Create(articleMaterial);
        }

        public void AddBookMaterial(BookMaterial bookMaterial)
        {
            bookMaterialRepository.Create(bookMaterial);
        }

        public void AddVideoMaterial(VideoMaterial videoMaterial)
        {
            videoMaterialRepository.Create(videoMaterial);
        }
        public IEnumerable<VideoMaterial> GetVideoMaterials()
        {
            return videoMaterialRepository.GetAll();
        }
        public IEnumerable<ArticleMaterial> GetArticleMaterials()
        {
            return articleMaterialRepository.GetAll();
        }

        public IEnumerable<BookMaterial> GetBookMaterials()
        {
            return bookMaterialRepository.GetAll();
        }

        public Material GetMaterialByName(string name)
        {
            return GetMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        public VideoMaterial GetVideoMaterialByName(string name)
        {
            return GetVideoMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        public BookMaterial GetBookMaterialByName(string name)
        {
            return GetBookMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
        public ArticleMaterial GetArticleMaterialByName(string name)
        {
            return GetArticleMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public IEnumerable<Material> GetMaterials()
        {
            List<Material> materials = new List<Material>();
            materials.AddRange(GetVideoMaterials());
            materials.AddRange(GetArticleMaterials());
            materials.AddRange(GetBookMaterials());
            return materials;
        }
    }
}
