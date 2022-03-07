using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class Balls
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("ball")]
        public int Ball { get; set; }
        [JsonProperty("id_km")]
        public int KmId { get; set; }
        [JsonProperty("id_stud")]
        public int StudId { get; set; }
    }
}