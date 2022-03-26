namespace OrioksDecorator.Models.News
{
    /// <summary>
    ///     Новость
    /// </summary>
    public sealed class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> FileLink { get; set; }
    }
}
