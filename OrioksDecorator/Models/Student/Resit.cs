using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public sealed class Resit
    {
        [JsonProperty("classroom")]
        public string Classroom { get; set; }
        [JsonProperty("datetime")]
        public string Datetime { get; set; }
        [JsonProperty("resit_number")]
        public int ResitNumber { get; set; }
    }
}
