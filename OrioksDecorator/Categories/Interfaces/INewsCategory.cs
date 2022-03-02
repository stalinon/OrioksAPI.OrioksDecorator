using OrioksDecorator.Models.News;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface INewsCategory
    {
        Task<IEnumerable<NewsItem>> GetNews(bool getDescriptions);

        Task<NewsItem> GetNewsItemsDesc(NewsItem item);
    }
}
