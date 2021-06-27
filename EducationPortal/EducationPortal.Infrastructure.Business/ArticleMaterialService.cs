using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Business
{
    public class ArticleMaterialService : IArticleMaterialService
    {
        private readonly IRepository<ArticleMaterial> articleMaterialRepository;

        public ArticleMaterialService(IRepository<ArticleMaterial> articleMaterialRepository)
        {
            this.articleMaterialRepository = articleMaterialRepository;
        }

        public async Task AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            await articleMaterialRepository.AddAsync(articleMaterial);
        }
    }
}
