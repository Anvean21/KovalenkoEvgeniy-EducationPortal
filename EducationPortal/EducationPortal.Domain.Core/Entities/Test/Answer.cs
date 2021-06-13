using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        [JsonIgnore]
        [NotMapped]
        public char[] Variant { get; set; }
    }
}
