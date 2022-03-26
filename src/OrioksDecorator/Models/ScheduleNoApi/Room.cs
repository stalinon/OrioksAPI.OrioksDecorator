using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public sealed class Room
	{
		[JsonProperty("Code")]
		public int Code { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

	}
}