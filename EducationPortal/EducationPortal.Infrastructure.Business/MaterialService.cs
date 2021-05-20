using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class MaterialService : IMaterialService
    {
        private IRepository<IMaterialService> materialRepository;
        public MaterialService(IRepository<IMaterialService> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public ArticleMaterial AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            throw new NotImplementedException();
        }

        public BookMaterial AddBookMaterial(BookMaterial bookMaterial)
        {
            throw new NotImplementedException();
        }

        public VideoMaterial AddVideoMaterial(VideoMaterial videoMaterial)
        {
            throw new NotImplementedException();
        }
    }
}
