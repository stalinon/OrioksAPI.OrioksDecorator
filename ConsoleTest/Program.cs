
using OrioksDecorator;

var client = await OrioksClient.Instance();

var res = await client.Teacher.GetAllTeacherInfos();

foreach (var teacher in res)
{
    Console.WriteLine(teacher.Name);
}