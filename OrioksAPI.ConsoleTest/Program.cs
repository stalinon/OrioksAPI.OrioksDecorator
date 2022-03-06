using OrioksDecorator;

var account = new OrioksAccount
{
    Username = "",
    Password = "",
    Token = ""
};

var client = await OrioksDecorator.OrioksDecorator.Instance(account);

//await News.NewsAsync(client);
//await Disciplines.DisciplinesAsync(client);