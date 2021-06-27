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
    public class VideoMaterialService : IVideoMaterialService
    {
        private readonly IRepository<VideoMaterial> videoMaterialRepository;

        public VideoMaterialService(IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.videoMaterialRepository = videoMaterialRepository;
        }

        public async Task AddVideoMaterial(VideoMaterial videoMaterial)
        {
            await videoMaterialRepository.AddAsync(videoMaterial);
        }
    }
}
