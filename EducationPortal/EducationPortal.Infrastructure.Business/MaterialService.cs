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
        private IRepository<Material> materialRepository;
        public MaterialService(IRepository<Material> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public void AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            materialRepository.Create(articleMaterial);
        }

        public void AddBookMaterial(BookMaterial bookMaterial)
        {
            materialRepository.Create(bookMaterial);
        }

        public void AddVideoMaterial(VideoMaterial videoMaterial)
        {
            materialRepository.Create(videoMaterial);
        }

        public Material GetMaterialByName(string name)
        {
            return materialRepository.GetAll().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public IEnumerable<Material> GetMaterials()
        {
            return materialRepository.GetAll();
        }
    }
}
