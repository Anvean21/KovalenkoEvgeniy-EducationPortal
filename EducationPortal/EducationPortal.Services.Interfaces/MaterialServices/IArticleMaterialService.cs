using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IArticleMaterialService
    {
        public void AddArticleMaterial(ArticleMaterial articleMaterial);
        public IEnumerable<ArticleMaterial> GetArticleMaterials();
        public ArticleMaterial GetArticleMaterialByName(string name);
    }
}
