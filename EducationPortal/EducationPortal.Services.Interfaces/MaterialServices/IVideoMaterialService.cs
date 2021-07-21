using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface IVideoMaterialService
    {
        public Task AddVideoMaterial(VideoMaterial videoMaterial);
    }
}
