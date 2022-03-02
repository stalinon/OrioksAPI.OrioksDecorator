namespace OrioksAPI.ConsoleTest.Examples
{
    internal static class News
    {
        internal static async Task NewsAsync(OrioksDecorator.OrioksDecorator client)
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
