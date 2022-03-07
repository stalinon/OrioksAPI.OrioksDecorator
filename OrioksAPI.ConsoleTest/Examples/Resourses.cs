using OrioksDecorator;

namespace OrioksAPI.ConsoleTest.Examples
{
    public static class Resourses
    {
        public static async Task GetResourseFromFirstOfCurrDisciplinesAsync(OrioksClient client)
        {
            var disciplines = await client.Disciplines.GetCurrentDisciplineInfos();
            var discipline = disciplines.Items.First();

            var resourses = await client.Disciplines.GetResoursesByDiscipline(discipline);

            foreach (var resourse in resourses.ResoursesList)
            {
                Console.WriteLine(resourse.Name);
                foreach (var items in resourse.ResourseItems)
                {
                    Console.WriteLine("\t" + items.Name);
                    Console.WriteLine("\t" + items.Link);
                    Console.WriteLine("\t" + items.Type);
                }
            }
        }
    }
}
