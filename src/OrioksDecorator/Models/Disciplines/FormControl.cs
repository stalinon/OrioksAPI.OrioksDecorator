using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public sealed class FormControl
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}