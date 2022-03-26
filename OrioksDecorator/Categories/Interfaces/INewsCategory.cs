using OrioksDecorator.Models.News;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория новостей
    /// </summary>
    public interface INewsCategory
    {
        /// <summary>
        ///     Получить все новости с/без 
        ///     подробных описаний
        /// </summary>
        Task<IEnumerable<NewsItem>> GetNews(bool getDescriptions);

        /// <summary>
        ///     Получить подробное описание
        ///     выбранной новости
        /// </summary>
        Task<NewsItem> GetNewsItemsDesc(NewsItem item);
    }
}
