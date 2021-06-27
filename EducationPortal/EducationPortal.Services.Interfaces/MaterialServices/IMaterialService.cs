using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Services.Interfaces
{
    public interface IMaterialService
    {
        public Task<Material> GetMaterialById(int Id);
        public bool UniqueMaterialName(string name);
        public IEnumerable<Material> GetVideoMaterials(int pageNumber = 1, int itemCount = 40);
        public IEnumerable<Material> GetBookMaterials(int pageNumber = 1, int itemCount = 40);
        public IEnumerable<Material> GetArticleMaterials(int pageNumber = 1, int itemCount = 40);
    }
}
