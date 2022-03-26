using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.ScheduleNoApi;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="IScheduleNoAPICategory"/>
    public sealed class ScheduleNoAPICategory : IScheduleNoAPICategory
    {
        private HttpClient _client;

        /// <inheritdoc cref="IScheduleNoAPICategory"/>
        public ScheduleNoAPICategory(HttpClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<DisciplineSchedule> GetDisciplineScheduleItemsAsync(string groupKey)
        {
            var baseUrl = $"https://miet.ru/schedule/data";
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("group", groupKey) });

            var response = await _client.PostAsync(baseUrl, content);
            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<DisciplineSchedule>(resultString);

            return result;
        }
    }
}
