using Newtonsoft.Json;

namespace OrioksDecorator.Models.Student
{
    /// <summary>
    ///     Информация о студенте
    /// </summary>
    public sealed class Student
    {
        [JsonProperty("course")]
        public int Course { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("group")]
        public string Group { get; set; }
        [JsonProperty("record_book_id")]
        public int RecordBookId { get; set; }
        [JsonProperty("semester")]
        public int Semester { get; set; }
        [JsonProperty("study_direction")]
        public string StudyDirection { get; set; }
        [JsonProperty("study_profile")]
        public string StudyProfile { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }

    }
}
