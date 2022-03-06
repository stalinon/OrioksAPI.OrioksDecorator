using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class Grade
    {
        [JsonProperty("o")]
        public string O { get; set; }
        [JsonProperty("p")]
        public string P { get; set; }
        [JsonProperty("b")]
        public string B { get; set; }
        [JsonProperty("w")]
        public string W { get; set; }
        [JsonProperty("c")]
        public string C { get; set; }
    }
}