using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class Lectern
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sh")]
        public string ShortName { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("id_zav")]
        public string IdZav { get; set; }
    }
}