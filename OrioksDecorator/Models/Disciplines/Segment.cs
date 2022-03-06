using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class Segment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("id_dis")]
        public int DisId { get; set; }
        [JsonProperty("allKms")]
        public IEnumerable<Event> Events { get; set; }
    }
}