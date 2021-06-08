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
        private readonly IVideoMaterialService videoMaterialService;
        private readonly IBookMaterialService bookMaterialService;
        private readonly IArticleMaterialService articleMaterialService;

        public MaterialService(IBookMaterialService bookMaterialService, IArticleMaterialService articleMaterialService, IVideoMaterialService videoMaterialService)
        {
            this.articleMaterialService = articleMaterialService;
            this.videoMaterialService = videoMaterialService;
            this.bookMaterialService = bookMaterialService;
        }

        public Material GetMaterialByName(string name)
        {
            return GetMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public IEnumerable<Material> GetMaterials()
        {
            List<Material> materials = new List<Material>();
            materials.AddRange(videoMaterialService.GetVideoMaterials());
            materials.AddRange(articleMaterialService.GetArticleMaterials());
            materials.AddRange(bookMaterialService.GetBookMaterials());
            return materials;
        }
    }
}
