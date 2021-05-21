using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IMaterialService
    {
        public void AddVideoMaterial(VideoMaterial videoMaterial);
        public void AddBookMaterial(BookMaterial bookMaterial);
        public void AddArticleMaterial(ArticleMaterial articleMaterial);
        public IEnumerable<Material> GetMaterials();
        public Material GetMaterialByName(string name);
    }
}
