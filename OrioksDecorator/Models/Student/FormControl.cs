using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public class FormControl
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}