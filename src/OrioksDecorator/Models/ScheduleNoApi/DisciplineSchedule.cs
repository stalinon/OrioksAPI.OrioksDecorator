using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
    /// <summary>
    ///     Расписание
    /// </summary>
    public sealed class DisciplineSchedule
    {
        [JsonProperty("Times")]
        public IEnumerable<Times> Times { get; set; }

        [JsonProperty("Data")]
        public IEnumerable<Data> Data { get; set; }

        [JsonProperty("Semestr")]
        public string Semestr { get; set; }
    }
}
