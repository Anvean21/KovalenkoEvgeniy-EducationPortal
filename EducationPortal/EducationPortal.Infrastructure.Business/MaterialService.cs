using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    //ИНТЕРФЕЙС
    public class MaterialService : IMaterialService
    {
        private IRepository<IMaterialService> materialRepository;
        public MaterialService(IRepository<IMaterialService> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        void IMaterialService.AddArticleMaterial(ArticleMaterial articleMaterial)
        {
            throw new NotImplementedException();
        }

        void IMaterialService.AddBookMaterial(BookMaterial bookMaterial)
        {
            throw new NotImplementedException();
        }

        void IMaterialService.AddVideoMaterial(VideoMaterial videoMaterial)
        {
            materialRepository.Create(videoMaterial);
        }
    }
}
