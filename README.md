# OrioksDecorator
Обертка над API orioks.miet.ru + скрапер. Реализация открытых API методов, а также больших за счет парсинга сайта.  

[`Краткая документация`](docs/doc.common.md)

![workflow](https://github.com/stalinon/OrioksAPI.OrioksDecorator/workflows/.NET/badge.svg) ![Nuget](https://img.shields.io/nuget/v/OrioksAPI.OrioksDecorator)

`На данный момент проект можно считать завершенным. По мере необходимости будут вноситься некоторые изменения, но, вообще говоря, на этом мои полномочия все.`

Для части работы с Rest API использован пакет [RestSharp](https://restsharp.dev/), 
для парсинга страниц - [AngleSharp](https://anglesharp.github.io/).

---

## Пример использования библиотеки

```c#
using OrioksDecorator;

var account = new OrioksAccount
{
    Username = "+++++",
    Password = "+++++",
    Token = "+++++"
};

var client = await OrioksClient.Instance(account);

var teacherInfo = client.Teacher.GetTeachersInfo("Пупкин Василий Петрович");

Console.WriteLine(teacherInfo.Biography);

```
