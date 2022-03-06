using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Disciplines;

namespace OrioksDecorator.Categories.Impl
{
    public class DisciplinesCategory : IDisciplinesCategory
    {
        private HttpClient _client;

        public DisciplinesCategory(HttpClient client)
        {
            _client = client;
        }

        public async Task<Disciplines> GetCurrentDisciplineInfos()
        {
            var baseUrl = "https://orioks.miet.ru/";
            var response = await _client.GetAsync(baseUrl+"student/student/");

            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var discJson = document.All.Where(m => m.LocalName == "div" && m.Id == "forang").First().TextContent;

            var discipline = JsonConvert.DeserializeObject<Disciplines>(discJson);

            return discipline;
        }

        public async Task<Disciplines> GetDisciplineInfoById(int semesterId, int studentId)
        {
            var baseUrl = "https://orioks.miet.ru/";
            var response = await _client.GetAsync(baseUrl + $"student/student?id_semester={semesterId}&student_id={studentId}");

            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var discJson = document.All.Where(m => m.LocalName == "div" && m.Id == "forang").First().TextContent;

            var discipline = JsonConvert.DeserializeObject<Disciplines>(discJson);

            return discipline;
        }
    }
}
