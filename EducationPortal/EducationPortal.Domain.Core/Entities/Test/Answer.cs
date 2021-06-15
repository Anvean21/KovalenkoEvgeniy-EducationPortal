using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Answer : BasicEntity
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        [JsonIgnore]
        [NotMapped]
        public char[] Variant { get; set; }
    }
}
