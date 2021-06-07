using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IBookMaterialService
    {
        public void AddBookMaterial(BookMaterial bookMaterial);
        public IEnumerable<BookMaterial> GetBookMaterials();
        public BookMaterial GetBookMaterialByName(string name);
    }
}
