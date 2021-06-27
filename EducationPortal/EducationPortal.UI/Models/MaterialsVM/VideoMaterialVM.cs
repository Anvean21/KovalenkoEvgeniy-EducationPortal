namespace EducationPortal.UI.Models
{
    public class VideoMaterialVM : MaterialVM
    {
        public VideoQualityVM Quality { get; set; }
        public string Duration { get; set; }
        public string Link { get; set; }
    }
}
