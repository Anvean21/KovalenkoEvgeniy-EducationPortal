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
    public class VideoMaterialService : IVideoMaterialService
    {
        private readonly IRepository<VideoMaterial> videoMaterialRepository;

        public VideoMaterialService(IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.videoMaterialRepository = videoMaterialRepository;
        }

        public void AddVideoMaterial(VideoMaterial videoMaterial)
        {
            videoMaterialRepository.AddAsync(videoMaterial);
        }
        public IEnumerable<VideoMaterial> GetVideoMaterials(int pageNumber = 1, int itemCount = 10)
        {
            return videoMaterialRepository.GetAsync(new Specification<VideoMaterial>(x => x.Id == x.Id), pageNumber, itemCount).Result.Items;
        }

        public VideoMaterial GetVideoMaterialByName(string name)
        {
            var videoSpecification = new Specification<VideoMaterial>(x => x.Name.ToLower() == name.ToLower());
            return videoMaterialRepository.FindAsync(videoSpecification).Result;
        }
    }
}
