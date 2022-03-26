using OrioksDecorator;
using System.Text.RegularExpressions;

var account = new OrioksAccount
{
    Username = "",
    Password = "",
    Token = ""
};

var client = await OrioksClient.Instance(account);



//await Resourses.GetResourseFromFirstOfCurrDisciplinesAsync(client);
//await News.NewsAsync(client);
//await Disciplines.DisciplinesAsync(client);