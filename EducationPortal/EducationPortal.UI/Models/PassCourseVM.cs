using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.UI.Models
{
    public class PassCourseVM
    {
        public CourseVM CourseVM { get; set; }
        public ICollection<VideoMaterialVM> Videos { get; set; }
        public ICollection<ArticleMaterialVM> Articles { get; set; }
        public ICollection<BookMaterialVM> Books { get; set; }
    }
}
