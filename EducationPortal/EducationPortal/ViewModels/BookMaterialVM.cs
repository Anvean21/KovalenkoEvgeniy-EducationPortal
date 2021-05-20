using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.ViewModels
{
   public class BookMaterialVM :MaterialVM
    {
        public int Pages { get; set; }
        public string Author { get; set; }
        public int YearOfPublish { get; set; }
        public BookFormatVM Format { get; set; }
    }
}
