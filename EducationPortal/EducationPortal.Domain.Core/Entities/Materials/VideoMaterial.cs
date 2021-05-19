using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
    public class VideoMaterial
    {
        public VideoQuality Quality { get; set; }
        public double Duration { get; set; }
        public string Path { get; set; }
    }
}
