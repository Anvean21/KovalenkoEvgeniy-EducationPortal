using System.Text.Json.Serialization;

namespace EducationPortal.Domain.Core.Entities
{
    public class Answer
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        [JsonIgnore]
        public char[] Variant { get; set; } = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    }
}
