using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Disciplines;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="IDisciplinesCategory"/>
    public sealed class DisciplinesCategory : IDisciplinesCategory
    {
        private HttpClient _client;

        /// <inheritdoc cref="IDisciplinesCategory"/>
        public DisciplinesCategory(HttpClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<Resourses> GetResoursesByDiscipline(Discipline discipline)
        {
            var disId = discipline.Id;
            var sciId = discipline.ScienceId;

            var baseUrl = "https://orioks.miet.ru/";
            var response = await _client.GetAsync(baseUrl + $"student/ir/?id_dis={disId}&id_science={sciId}");

            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var groups = document.All.Where(m => m.ClassList.Contains("list-group")).ToList();


            var result = new Resourses
            {
                DisId = disId,
                SciId = (int)sciId,
                DisName = discipline.Name
            };

            var resList = new List<Resourse>();

            foreach (var group in groups)
            {
                var name = group.QuerySelector("div.list-group-item").TextContent;
                var resourses = group.QuerySelector(".panel-collapse").ChildNodes.Where(x => (x is IHtmlDivElement));

                var res = new Resourse
                {
                    Name = name,
                };

                var resItems = new List<ResourseItem>();

                resList.Add(res);

                foreach (var resourse in resourses)
                {
                    var link = (resourse as IElement).QuerySelector("a");
                    var resourseName = link.TextContent;
                    var resourseLink = link.GetAttribute("href");
                    var resourseType = (resourse as IElement).QuerySelector("span.label").TextContent;

                    var resourseItem = new ResourseItem
                    {
                        Name = resourseName,
                        Link = resourseLink,
                        Type = resourseType
                    };

                    resItems.Add(resourseItem);
                }

                res.ResourseItems = resItems;
            }

            result.ResoursesList = resList;

            return result;

        }
    }
}
