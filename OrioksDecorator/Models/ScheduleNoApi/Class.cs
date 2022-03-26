using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public class Class
	{
		[JsonProperty("Code")]
		public string Code { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("TeacherFull")]
		public string TeacherFull { get; set; }

		[JsonProperty("Teacher")]
		public string Teacher { get; set; }

		[JsonProperty("Form")]
		public string Form { get; set; }

	}
}
