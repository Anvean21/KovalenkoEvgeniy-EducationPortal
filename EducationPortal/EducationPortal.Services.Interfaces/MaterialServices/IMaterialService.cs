using EducationPortal.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Services.Interfaces
{
    public interface IMaterialService
    {
        public IEnumerable<Material> GetMaterials();
        public Material GetMaterialByName(string name);
    }
}
