using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationPortal.Domain.Core
{
   public class ArticleMaterial:Material
    {
        public DateTime PublishDate { get; set; }
        public string Resource { get; set; }
    }
}
