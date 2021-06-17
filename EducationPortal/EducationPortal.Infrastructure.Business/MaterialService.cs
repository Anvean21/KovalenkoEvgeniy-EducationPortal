using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepository<Material> materialRepository;

        public MaterialService(IRepository<Material> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public Material GetMaterialById(int Id)
        {
            var materialSpecification = new Specification<Material>(x => x.Id == Id);
            return materialRepository.FindAsync(materialSpecification).Result;
        }

        public IEnumerable<Material> GetMaterials(int pageNumber = 1, int itemCount = 40)
        {
            var materialSpecification = new Specification<Material>(x => x.Id == x.Id);

            return materialRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }

        public IEnumerable<Material> GetVideoMaterials(int pageNumber = 1, int itemCount = 40)
        {
            var materialSpecification = new Specification<Material>(x => x.Id == x.Id && x is VideoMaterial);

            return materialRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }

        public IEnumerable<Material> GetBookMaterials(int pageNumber = 1, int itemCount = 40)
        {
            var materialSpecification = new Specification<Material>(x => x.Id == x.Id && x is BookMaterial);

            return materialRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }

        public IEnumerable<Material> GetArticleMaterials(int pageNumber = 1, int itemCount = 40)
        {
            var materialSpecification = new Specification<Material>(x => x.Id == x.Id && x is ArticleMaterial);

            return materialRepository.GetAsync(materialSpecification, pageNumber, itemCount).Result.Items;
        }
    }
}
