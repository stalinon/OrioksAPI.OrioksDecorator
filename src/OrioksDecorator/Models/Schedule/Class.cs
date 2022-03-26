using Newtonsoft.Json;

namespace OrioksDecorator.Models.Schedule
{
    public sealed class Class
    {
        [JsonProperty("1")]
        public IEnumerable<string> First { get; set; }
        [JsonProperty("2")]
        public IEnumerable<string> Second { get; set; }
        [JsonProperty("3")]
        public IEnumerable<string> Third { get; set; }
        [JsonProperty("4")]
        public IEnumerable<string> Fourth { get; set; }
        [JsonProperty("5")]
        public IEnumerable<string> Fifth { get; set; }
        [JsonProperty("6")]
        public IEnumerable<string> Sixth { get; set; }
        [JsonProperty("7")]
        public IEnumerable<string> Seventh { get; set; }

    }
}
