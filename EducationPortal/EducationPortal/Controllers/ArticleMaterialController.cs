using EducationPortal.Automapper;
using EducationPortal.Domain.Core;
using EducationPortal.FluentValidationModels;
using EducationPortal.Helpers;
using EducationPortal.Services.Interfaces;
using EducationPortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Controllers
{
    public class ArticleMaterialController
    {
        readonly IArticleMaterialService articleMaterialService;
        private readonly IMapper mapper;

        readonly ArticleMaterialValidator acticleValidator = new ArticleMaterialValidator();
        readonly MaterialValidator validations = new MaterialValidator();

        readonly MaterialHelper materialHelper = new MaterialHelper();

        public ArticleMaterialController(IArticleMaterialService articleMaterialService, IMapper mapper)
        {
            this.articleMaterialService = articleMaterialService;
            this.mapper = mapper;
        }

        public ArticleMaterialVM ArticleCreate()
        {
            var articleVM = materialHelper.ArticleFullData();

            if (validations.Validate(articleVM).IsValid && acticleValidator.Validate(articleVM).IsValid)
            {
                var mappedArticle = mapper.Map<ArticleMaterialVM, ArticleMaterial>(articleVM);
                articleMaterialService.AddArticleMaterial(mappedArticle);

                Dye.Succsess();
                Console.WriteLine("You have add article");
                Console.ResetColor();
                return articleVM;
            }
            else
            {
                Dye.Fail();
                Console.WriteLine(acticleValidator.Validate(articleVM) + " " + " " + validations.Validate(articleVM));
                Console.ResetColor();
                ArticleCreate();
                return null;
            }
        }
    }
}
