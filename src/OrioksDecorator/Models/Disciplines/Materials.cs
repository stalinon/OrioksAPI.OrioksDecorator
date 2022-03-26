using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public sealed class Materials
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_test")]
        public bool IsTest { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}