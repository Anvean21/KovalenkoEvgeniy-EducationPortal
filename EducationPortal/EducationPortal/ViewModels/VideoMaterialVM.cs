using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels
{
   public class VideoMaterialVM : MaterialVM
    {
        public VideoQualityVM Quality { get; set; }
        public double Duration { get; set; }
        public string Path { get; set; }
    }
}
