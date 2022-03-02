using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
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