using Newtonsoft.Json;

namespace OrioksDecorator.Models.Schedule
{
    public class Schedule
    {
        [JsonProperty("semester_start")]
        public string SemesterStart { get; set; }
        [JsonProperty("session_start")]
        public string SessionStart { get; set; }
        [JsonProperty("session_end")]
        public string SessionEnd { get; set; }
        [JsonProperty("next_semester_start")]
        public string NextSemesterStart { get; set; }
    }
}
