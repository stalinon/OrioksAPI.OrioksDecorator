using OrioksDecorator;

var account = new OrioksAccount
{
    Username = "8191466",
    Password = "@utop1l0t243",
    Token = ""
};

var client = await OrioksClient.Instance(account);



//await Resourses.GetResourseFromFirstOfCurrDisciplinesAsync(client);
//await News.NewsAsync(client);
//await Disciplines.DisciplinesAsync(client);
var res = await client.ScheduleNoApi.GetDisciplineScheduleItemsAsync("ПМ-31");
Console.WriteLine(res.Semestr);