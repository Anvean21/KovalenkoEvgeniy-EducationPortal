using EducationPortal.Domain.Core;
using EducationPortal.Domain.Interfaces;
using EducationPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationPortal.Infrastructure.Business
{
    public class VideoMaterialService : IVideoMaterialService
    {
        private readonly IRepository<VideoMaterial> videoMaterialRepository;

        public VideoMaterialService(IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.videoMaterialRepository = videoMaterialRepository;
        }

        public void AddVideoMaterial(VideoMaterial videoMaterial)
        {
            videoMaterialRepository.Create(videoMaterial);
        }

        public IEnumerable<VideoMaterial> GetVideoMaterials()
        {
            return videoMaterialRepository.GetAsync();
        }

        public VideoMaterial GetVideoMaterialByName(string name)
        {
            return videoMaterialRepository.GetAsync(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
