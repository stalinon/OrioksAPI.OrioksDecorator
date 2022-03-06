using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    public class Disciplines
    {
        [JsonProperty("dises")]
        public IEnumerable<Discipline> Items { get; set; }
    }
}
