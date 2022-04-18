using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.ScheduleNoApi;
using System.Text;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="IScheduleNoAPICategory"/>
    internal sealed class ScheduleNoAPICategory : IScheduleNoAPICategory
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

            return result!;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<string>> GetGroupKeys()
        {
            var baseUrl = $"https://miet.ru/schedule/groups";
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>() });

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            request.Content = content;
            request.Content.Headers.ContentLength = 0;
            request.Headers.Host = "miet.ru";

            
            var response = await _client.SendAsync(request);
            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<string>>(resultString);

            return result!;
        }
    }
}
