using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public class Science
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("kaf")]
        public Lectern Lectern { get; set; }
    }
}