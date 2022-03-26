using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public class Group
	{
		[JsonProperty("Code")]
		public string Code { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

	}
}