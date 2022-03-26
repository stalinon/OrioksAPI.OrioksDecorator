using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public sealed class Teacher
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}