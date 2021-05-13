using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Core
{
   public class BookMaterial:Material
    {

        public int Pages { get; set; }
        public string Author { get; set; }
        public DateTime YearOfPublish { get; set; }
        public BookFormat Format { get; set; }
    }
}
