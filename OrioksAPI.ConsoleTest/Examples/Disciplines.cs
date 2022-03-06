namespace OrioksAPI.ConsoleTest.Examples
{
    internal static class Disciplines
    {
        internal static async Task DisciplinesAsync(OrioksDecorator.OrioksDecorator client)
        {
            var discipline = await client.Disciplines.GetDisciplineInfos();
            var list = discipline.Items;

            foreach (var item in list)
            {
                Console.WriteLine("Название предмета: " + item.Name);
                foreach (var prep in item.Teachers)
                {
                    Console.WriteLine(prep.Name);
                }
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}
