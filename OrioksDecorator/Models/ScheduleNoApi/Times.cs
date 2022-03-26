using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public class Times
	{
		[JsonProperty("Time")]
		public string Time { get; set; }

		[JsonProperty("Code")]
		public int Code { get; set; }

		[JsonProperty("TimeFrom")]
		public string TimeFrom { get; set; }

		[JsonProperty("TimeTo")]
		public string TimeTo { get; set; }

	}
}