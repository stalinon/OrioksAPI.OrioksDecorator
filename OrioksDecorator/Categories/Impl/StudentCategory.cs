using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Disciplines;
using OrioksDecorator.Models.Student;
using RestSharp;

namespace OrioksDecorator.Categories.Impl
{
    public class StudentCategory : IStudentCategory
    {
        private readonly RestClient _client;

        public StudentCategory(RestClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AcademicDebts>> GetAcademicDebts()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/student/academic-debts",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<AcademicDebts>>(response.Content);
        }

        public async Task<IEnumerable<Discipline>> GetDisciplines()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/student/disciplines",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<Discipline>>(response.Content);
        }

        public async Task<IEnumerable<Event>> GetEventsByDisciplineId(int disciplineId)
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/student/disciplines/{disciplineId}/events",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<Event>>(response.Content);
        }

        public async Task<IEnumerable<Resit>> GetResitsByDebtId(int debtId)
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/student/academic-debts/{debtId}/resits",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<IEnumerable<Resit>>(response.Content);
        }

        public async Task<Student> GetStudentInfo()
        {
            var request = new RestRequest
            {
                Resource = $"/api/v1/student",
                Method = Method.Get
            };

            var response = await _client.GetAsync(request);

            return JsonConvert.DeserializeObject<Student>(response.Content);
        }
    }
}
