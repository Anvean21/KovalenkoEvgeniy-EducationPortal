using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels
{
    public class VideoMaterialVM : MaterialVM
    {
        public VideoQualityVM Quality { get; set; }
        public string Duration { get; set; }
    }
}
