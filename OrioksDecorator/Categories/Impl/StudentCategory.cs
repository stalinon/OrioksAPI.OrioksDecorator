using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Student;

namespace OrioksDecorator.Categories.Impl
{
    public class StudentCategory : IStudentCategory
    {
        private HttpClient _client;

        public StudentCategory(HttpClient client)
        {
            _client = client;
        }

        public async Task<Disciplines> GetDisciplineInfos()
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
    }
}
