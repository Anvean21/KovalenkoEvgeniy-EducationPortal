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
            articleMaterialRepository.SaveAsync();
        }
    }
}
