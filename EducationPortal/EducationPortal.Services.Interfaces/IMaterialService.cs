using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IMaterialService
    {
        public VideoMaterial AddVideoMaterial(VideoMaterial videoMaterial);
        public BookMaterial AddBookMaterial(BookMaterial bookMaterial);
        public ArticleMaterial AddArticleMaterial(ArticleMaterial articleMaterial);
    }
}
