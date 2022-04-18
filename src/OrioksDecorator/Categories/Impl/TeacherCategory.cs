using AngleSharp.Html.Parser;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Teacher;
using OrioksDecorator.Utility;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="ITeacherCategory"/>
    internal sealed class TeacherCategory : ITeacherCategory
    {
        private HttpClient _client;

        /// <inheritdoc cref="ITeacherCategory"/>
        public TeacherCategory(HttpClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<Teacher> GetTeachersInfo(string name)
        {
            var baseUrl = Dict.Links[name.First().ToString().ToUpper()];
            var response = await _client.GetAsync(baseUrl);

            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var link = "https://miet.ru" + document.QuerySelectorAll("a").Where(a => a.TextContent == name).First().GetAttribute("href");
            
            response = await _client.GetAsync(link);

            html = await response.Content.ReadAsStringAsync();

            parser = new HtmlParser();
            document = parser.ParseDocument(html);

            var teacher = new Teacher
            {
                Name = name,
                Degree = document.QuerySelector("span.people-content__post")!.TextContent,
                Email = document.QuerySelector("a.people-content__info-list__item-email")!.TextContent,
                PhoneNumber = document.QuerySelector("span.people-content__info-list__item-phone")!.TextContent,
                Auditory = document.QuerySelector("span.people-content__info-list__item-number")!.TextContent,
                Position = document.QuerySelectorAll("span.people-content__info-list__item-elem")[1].TextContent,
                Chapter = document.QuerySelector("a.people-content__info-list__item-link")!.TextContent,
                Biography = document.QuerySelector("div.people-content__biography")!.TextContent,
                Courses = document.QuerySelector("div.people-content__courses")!.TextContent,
                Science = document.QuerySelector("div.people-content__science")!.TextContent,
                ImageUrl = "https://miet.ru"+document.QuerySelector("div.people-content__image")!.GetAttribute("style")!.Split(new[] { '(', ')' })[1]
            };

            return teacher;
        }
    }
}
