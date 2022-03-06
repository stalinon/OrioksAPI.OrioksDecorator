using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class FormControl
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}