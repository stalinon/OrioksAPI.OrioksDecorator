using AngleSharp.Html.Parser;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Models.News;

namespace OrioksDecorator.Categories.Impl
{
    /// <inheritdoc cref="INewsCategory"/>
    internal sealed class NewsCategory : INewsCategory
    {
        private HttpClient _client;

        /// <inheritdoc cref="INewsCategory"/>
        public NewsCategory(HttpClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<NewsItem>> GetNews(bool getDescriptions)
        {
            var baseUrl = "https://orioks.miet.ru/";
            var response = await _client.GetAsync(baseUrl);

            var html = await response.Content.ReadAsStringAsync();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var list = new List<NewsItem>();
            var id = 1;

            foreach (var element in document.QuerySelectorAll("tr").Skip(1))
            {
                var strings = element.QuerySelectorAll("td");

                if (strings.Count() != 3)
                    break;

                var url = baseUrl + strings[2].FirstElementChild!.GetAttribute("href");

                var news = new NewsItem
                {
                    Id = id++,
                    Date = DateTime.ParseExact(strings[0].TextContent, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                    Title = strings[1].TextContent,
                    Url = url,
                    Description = default
                };

                if (getDescriptions)
                    news = await GetNewsItemsDesc(news);

                list.Add(news);
                id++;
            }

            return list;
        }

        /// <inheritdoc />
        public async Task<NewsItem> GetNewsItemsDesc(NewsItem item)
        {
            var parser = new HtmlParser();

            var response = await _client.GetAsync(item.Url);
            var html = await response.Content.ReadAsStringAsync();

            var document = parser.ParseDocument(html);

            var body = document.QuerySelectorAll("div.well").First().TextContent.Split("Тело новости:").Last();

            var link = document.QuerySelectorAll("p").Select(x => x.QuerySelectorAll("a").FirstOrDefault()).Select(x => x != null ? x.GetAttribute("href") : string.Empty);

            var desc = string.Join('\n', body);

            item.Description = desc;
            item.FileLink = link!;

            return item;
        }

    }
}
