using AGL.DevelopersTest.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AGL.DevelopersTest.Models
{
    public class Pet
    {
        public string name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PetType type { get; set; }
        public virtual Person Owner { get; set; }
    }
}