# OrioksDecorator
Обертка над API orioks.miet.ru + скрапер. Реализация открытых API методов, а также больших за счет парсинга сайта.  
---
## Пример использования

```c#
using OrioksAPI;

var account = new OrioksAccount
{
    Username = "+++++",
    Password = "+++++",
    Token = "+++++"
};

var client = new OrioksClient(account);

var studentInfo = await client.Student.GetStudentInfo();

var fullName = studentInfo.FullName; // ФИО

var course = studentInfo.Course; // Курс
```

Для доступа к категориям Schedule и Student требуется использование токена, который выдается при аутентификации. Его можно получить не более 8 раз.
Получение токена требуется провести самостоятельно путем использования GET /api/v1/auth с стандартной Basic авторизацией.

## Возможности

В обертке имплементированы все стабильные методы оригинального REST API по двум категориям:
- Schedule (получение расписаний, групп и т.д.)
- Student (получение задолжностей, текущей успеваемости и т.д.)
А также методы, реализованные с помощью скрапинга сайта:
- News (новости на главной странице)
- Disciplines (информация о предметах в текущем семестре с /student/student, кроме того есть возможность получить информацию о предметах произвольного семестра, если имеется id семестра и студента, имеющего доступ)

## Планы

(01/03/2022)
В теории возможна реализация допфункций, не включенных в открытый API, путем отправки запросов "в лоб". Для этого вероятна последующая разработка еще одной библиотеки позже.
(07/03/2022)
Реализованы две категории путем парсинга html-страниц сайта.
