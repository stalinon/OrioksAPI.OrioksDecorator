
using OrioksAPI.ConsoleTest.Examples;
using OrioksDecorator;

var account = new OrioksAccount
{
    Username = "",
    Password = ""
};

var client = await OrioksDecorator.OrioksDecorator.Instance(account);

// await News.NewsAsync(client);
// await Student.DisciplinesAsync(client);