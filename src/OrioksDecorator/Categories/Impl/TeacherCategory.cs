using AngleSharp.Html.Parser;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.Teacher;
using OrioksDecorator.Utility;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="ITeacherCategory"/>
    public sealed class TeacherCategory : ITeacherCategory
    {
        private HttpClient _client;

        /// <inheritdoc cref="ITeacherCategory"/>
        public TeacherCategory(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherInfos()
        {
            var result = new List<Teacher>();

            foreach (var baseUrl in Dict.Links.Values)
            {
                var response = await _client.GetAsync(baseUrl);

                var html = await response.Content.ReadAsStringAsync();

                var parser = new HtmlParser();
                var document = parser.ParseDocument(html);

                var links = document.QuerySelectorAll("a.people-list__item-name");

                foreach (var item in links)
                {
                    var link = "https://miet.ru" + item.GetAttribute("href");
                    response = await _client.GetAsync(link);

                    html = await response.Content.ReadAsStringAsync();

                    parser = new HtmlParser();
                    document = parser.ParseDocument(html);

                    var name = document.QuerySelector("span.people-content__name");
                    var degree = document.QuerySelector("span.people-content__post");
                    var email = document.QuerySelector("a.people-content__info-list__item-email");
                    var phoneNumber = document.QuerySelector("span.people-content__info-list__item-phone");
                    var auditory = document.QuerySelector("span.people-content__info-list__item-number");
                    var position = document.QuerySelectorAll("span.people-content__info-list__item-elem");
                    var chapter = document.QuerySelector("a.people-content__info-list__item-link");
                    var biography = document.QuerySelector("div.people-content__biography");
                    var courses = document.QuerySelector("div.people-content__courses");
                    var science = document.QuerySelector("div.people-content__science");
                    var imageUrl = document.QuerySelector("div.people-content__image");

                    var teacher = new Teacher
                    {
                        Name = name != null ? name.TextContent : default!,
                        Degree = degree != null ? degree.TextContent : default!,
                        Email = email != null ? email.TextContent : default!,
                        PhoneNumber = phoneNumber != null ? phoneNumber.TextContent : default!,
                        Auditory = auditory != null ? auditory.TextContent : default!,
                        Position = position.Length != 0 ? position[1].TextContent : default!,
                        Chapter = chapter != null ? chapter.TextContent : default!,
                        Biography = biography != null ? biography.TextContent : default!,
                        Courses = courses != null ? courses.TextContent : default!,
                        Science = science != null ? science.TextContent : default!,
                        ImageUrl = imageUrl != null ? "https://miet.ru" + imageUrl.GetAttribute("style")!.Split(new[] { '(', ')' })[1] : default!
                    };

                    result.Add(teacher);
                }
            }

            return result;
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

            var degree = document.QuerySelector("span.people-content__post");
            var email = document.QuerySelector("a.people-content__info-list__item-email");
            var phoneNumber = document.QuerySelector("span.people-content__info-list__item-phone");
            var auditory = document.QuerySelector("span.people-content__info-list__item-number");
            var position = document.QuerySelectorAll("span.people-content__info-list__item-elem");
            var chapter = document.QuerySelector("a.people-content__info-list__item-link");
            var biography = document.QuerySelector("div.people-content__biography");
            var courses = document.QuerySelector("div.people-content__courses");
            var science = document.QuerySelector("div.people-content__science");
            var imageUrl = document.QuerySelector("div.people-content__image");

            var teacher = new Teacher
            {
                Name = name,
                Degree = degree != null ? degree.TextContent : default!,
                Email = email != null ? email.TextContent : default!,
                PhoneNumber = phoneNumber != null ? phoneNumber.TextContent : default!,
                Auditory = auditory != null ? auditory.TextContent : default!,
                Position = position != null ? position[1].TextContent : default!,
                Chapter = chapter != null ? chapter.TextContent : default!,
                Biography = biography != null ? biography.TextContent : default!,
                Courses = courses != null ? courses.TextContent : default!,
                Science = science != null ? science.TextContent : default!,
                ImageUrl = imageUrl != null ? "https://miet.ru" + imageUrl.GetAttribute("style")!.Split(new[] { '(', ')' })[1] : default!
            };

            return teacher;
        }
    }
}
