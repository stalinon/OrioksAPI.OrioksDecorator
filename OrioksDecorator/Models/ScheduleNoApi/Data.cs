using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public class Data
	{
		[JsonProperty("Day")]
		public int Day { get; set; }

		[JsonProperty("DayNumber")]
		public int DayNumber { get; set; }

		[JsonProperty("Time")]
		public Times Time { get; set; }

		[JsonProperty("Class")]
		public Class Class { get; set; }

		[JsonProperty("Group")]
		public Group Group { get; set; }

		[JsonProperty("Room")]
		public Room Room { get; set; }

	}
}