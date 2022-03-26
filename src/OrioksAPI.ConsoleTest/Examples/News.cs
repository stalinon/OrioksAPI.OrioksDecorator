using OrioksDecorator;

namespace OrioksAPI.ConsoleTest.Examples
{
    internal static class News
    {
        internal static async Task NewsAsync(OrioksClient client)
        {
            var list = await client.News.GetNews(false);

            foreach (var item in list)
            {
                Console.WriteLine("Заголовок: " + item.Title + "\n" + "Описание" + item.Description);
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}
