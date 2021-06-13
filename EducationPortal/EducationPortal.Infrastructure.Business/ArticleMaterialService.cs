using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class ArticleMaterialService : IArticleMaterialService
    {
        private readonly IRepository<ArticleMaterial> articleMaterialRepository;

        public ArticleMaterialService(IRepository<ArticleMaterial> articleMaterialRepository)
        {
            this.articleMaterialRepository = articleMaterialRepository;
        }

        public void AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            articleMaterialRepository.Create(articleMaterial);
        }

        public IEnumerable<ArticleMaterial> GetArticleMaterials()
        {
            return articleMaterialRepository.GetAsync();
        }

        public ArticleMaterial GetArticleMaterialByName(string name)
        {
            return articleMaterialRepository.GetAsync(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
