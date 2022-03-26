using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Schedule;
using RestSharp;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="IScheduleCategory"/>
    public sealed class ScheduleCategory : IScheduleCategory
    {

        private readonly RestClient _client;

        /// <inheritdoc cref="IScheduleCategory"/>
        public ScheduleCategory(RestClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<int> GetCurrentWeekAsync()
        {
            var schedule = await GetShedule();

            if (DateTime.TryParse(schedule.SemesterStart, out DateTime semesterStart))
            {
                var timeDelta = DateTime.UtcNow - semesterStart;
                return ((int)(timeDelta.TotalDays / 7 + 1));
            }

            return 0;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/schedule/groups",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<Group>>(response.Content);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ScheduleItem>> GetScheduleByGroupIdAsync(int groupId)
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/schedule/groups/{groupId}",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<ScheduleItem>>(response.Content);
        }

        /// <inheritdoc />
        public async Task<Class> GetTimetableAsync()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/schedule/timetable",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<Class>(response.Content);
        }

        /// <inheritdoc />
        public async Task<int> GetWeekTypeAsync()
        {
            var schedule = await GetShedule();

            if (DateTime.TryParse(schedule.SemesterStart, out DateTime semesterStart))
            {
                var timeDelta = DateTime.UtcNow - semesterStart;
                return (int)((timeDelta.TotalDays / 7) % 4);
            }

            return default;
        }

        private async Task<Schedule> GetShedule()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/schedule",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<Schedule>(response.Content);
        }
    }
}
