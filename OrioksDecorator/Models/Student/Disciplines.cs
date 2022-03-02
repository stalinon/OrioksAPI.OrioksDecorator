using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public class Disciplines
    {
        [JsonProperty("dises")]
        public IEnumerable<Discipline> Items { get; set; }
    }
}
