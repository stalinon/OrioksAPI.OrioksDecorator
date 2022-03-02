using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("bonus")]
        public int Bonus { get; set; }
        [JsonProperty("max_ball")]
        public int MaxBall { get; set; }
        [JsonProperty("week")]
        public int Week { get; set; }
        [JsonProperty("type")]
        public TypeEvent Type { get; set; }
        [JsonProperty("grade")]
        public Grade Grade { get; set; }
        [JsonProperty("irs")]
        public IEnumerable<Materials> Materials { get; set; }
    }
}