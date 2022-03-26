using Newtonsoft.Json;

namespace OrioksDecorator.Models.Schedule
{
    public sealed class Group
    {
        [JsonProperty("id")]

        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
