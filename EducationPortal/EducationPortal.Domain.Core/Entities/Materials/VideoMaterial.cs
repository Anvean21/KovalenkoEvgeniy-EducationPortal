using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class VideoMaterial : Material
    {
        public VideoQuality Quality { get; set; }
        public string Duration { get; set; }
        public string Link { get; set; }
    }
}
