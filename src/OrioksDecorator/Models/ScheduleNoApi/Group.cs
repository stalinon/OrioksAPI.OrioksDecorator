using Newtonsoft.Json;

namespace OrioksDecorator.Models.ScheduleNoApi
{
	public sealed class Group
	{
		[JsonProperty("Code")]
		public string Code { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

	}
}