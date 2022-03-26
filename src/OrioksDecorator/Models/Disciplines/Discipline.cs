using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    /// <summary>
    ///     Дисциплина
    /// </summary>
    public sealed class Discipline
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id_science")]
        public int? ScienceId { get; set; }
        [JsonProperty("plan_seminar")]
        public int? PlanSeminar { get; set; }
        [JsonProperty("plan_lecture")]
        public int? PlanLecture { get; set; }
        [JsonProperty("plan_lab")]
        public int? PlanLab { get; set; }
        [JsonProperty("plan_srs")]
        public int? PlanSrs { get; set; }
        [JsonProperty("id_dis")]
        public int? DisId { get; set; }
        [JsonProperty("segments")]
        public IEnumerable<Segment> Segments { get; set; }
        [JsonProperty("science")]
        public Science Science { get; set; }
        [JsonProperty("formControl")]
        public FormControl FormControl { get; set; }
        [JsonProperty("preps")]
        public IEnumerable<Teacher> Teachers { get; set; }

        [JsonProperty("balls")]
        public Balls Balls { get; set; }

        [JsonProperty("grade_full")]
        public Grade Grade { get; set; }
        [JsonProperty("date_exam")]
        public string DateExam { get; set; }
        [JsonProperty("date_cons")]
        public string DateCons { get; set; }
        [JsonProperty("time_exam")]
        public string TimeExam { get; set; }
        [JsonProperty("time_cons")]
        public string TimeCons { get; set; }
        [JsonProperty("room_exam")]
        public string RoomExam { get; set; }
        [JsonProperty("room_cons")]
        public string RoomCons { get; set; }
        [JsonProperty("debt")]
        public bool Debt { get; set; }
    }
}
