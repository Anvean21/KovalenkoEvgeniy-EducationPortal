﻿using EducationPortal.Domain.Core;
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

        public void AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            articleMaterialRepository.Create(articleMaterial);
        }
        public IEnumerable<ArticleMaterial> GetArticleMaterials()
        {
            return articleMaterialRepository.GetAll();
        }
        public ArticleMaterial GetArticleMaterialByName(string name)
        {
            return GetArticleMaterials().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}