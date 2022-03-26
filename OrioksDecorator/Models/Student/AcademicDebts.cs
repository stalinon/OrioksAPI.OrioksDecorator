using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    public sealed class AcademicDebts
    {
        [JsonProperty("consultation_schedule")]
        public string ConsultationSchedule { get; set; }
        [JsonProperty("control_form")]
        public string ControlForm { get; set; }
        [JsonProperty("current_grade")]
        public float CurrentGrade { get; set; }
        [JsonProperty("deadline")]
        public string Deadline { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("max_grade")]
        public float MaxGrade { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("teachers")]
        public IEnumerable<string> Teachers { get; set; }
    }
}
