using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public sealed class TypeEvent
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("important")]
        public int IsImportant { get; set; }
    }
}