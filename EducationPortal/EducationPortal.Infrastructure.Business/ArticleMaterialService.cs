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
    public class ArticleMaterialService : IArticleMaterialService
    {
        private readonly IRepository<ArticleMaterial> articleMaterialRepository;

        public ArticleMaterialService(IRepository<ArticleMaterial> articleMaterialRepository)
        {
            this.articleMaterialRepository = articleMaterialRepository;
        }

        public void AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            articleMaterialRepository.AddAsync(articleMaterial);
        }

        public IEnumerable<ArticleMaterial> GetArticleMaterials(int pageNumber = 1, int itemCount = 10)
        {
            return articleMaterialRepository.GetAsync(new Specification<ArticleMaterial>(x => x.Id == x.Id), pageNumber, itemCount).Result.Items;
        }

        public ArticleMaterial GetArticleMaterialByName(string name)
        {
            var articleSpecification = new Specification<ArticleMaterial>(x => x.Name.ToLower() == name.ToLower());
            return articleMaterialRepository.FindAsync(articleSpecification).Result;
        }
    }
}
