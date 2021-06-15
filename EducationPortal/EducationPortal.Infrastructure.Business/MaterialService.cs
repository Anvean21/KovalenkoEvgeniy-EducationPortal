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

        public Material GetMaterialByName(string name)
        {
            var materialSpecification = new Specification<Material>(x => x.Name.ToLower() == name.ToLower());
            return materialRepository.FindAsync(materialSpecification).Result;
        }

        public IEnumerable<Material> GetMaterials()
        {
            var materialSpecification = new Specification<Material>(x => x.Id == x.Id);
            return materialRepository.GetAsync(materialSpecification).Result;
        }
    }
}
