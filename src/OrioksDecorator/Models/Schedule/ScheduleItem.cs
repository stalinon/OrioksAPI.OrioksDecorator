using Newtonsoft.Json;

namespace OrioksDecorator.Models.Schedule
{
    /// <summary>
    ///     Элемент расписания
    /// </summary>
    public sealed class ScheduleItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("day")]
        public int Day { get; set; }
        [JsonProperty("class")]
        public int Class { get; set; }
        [JsonProperty("week")]
        public int Week { get; set; }
        [JsonProperty("week_recurrence")]
        public int WeekRecurrence { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("teacher")]
        public string Teacher { get; set; }
    }
}
