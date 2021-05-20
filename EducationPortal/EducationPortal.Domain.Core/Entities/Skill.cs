using EducationPortal.Domain.Core.Entities.RelationEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core
{
    public class Skill : BasicEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        [JsonIgnore]
        public IList<ExistingUserSkills> ExistingUserSkills { get; set; }
    }
}
