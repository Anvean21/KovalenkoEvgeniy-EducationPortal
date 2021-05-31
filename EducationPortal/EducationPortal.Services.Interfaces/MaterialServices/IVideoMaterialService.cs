﻿using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IVideoMaterialService
    {
        public void AddVideoMaterial(VideoMaterial videoMaterial);
        public IEnumerable<VideoMaterial> GetVideoMaterials();
        public VideoMaterial GetVideoMaterialByName(string name);
    }
}