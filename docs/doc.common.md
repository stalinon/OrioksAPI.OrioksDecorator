# Документация по библиотеке `OrioksDecorator`

В данном файле содержатся пометки, уточняющие использование библиотеки, ее структуру и принципы работы.

Ниже приводится список разделов, доступных для ознакомления:

1. [Структура библиотеки](#Структура_библиотеки).
2. [Доступные методы и их описание](#Доступные_методы_и_их_описание).
3. [Пакеты, использованные в разработке](#Пакеты,_использованные_в_разработке).



<a name="Структура_библиотеки"> ## Структура библиотеки </a> 

Библиотека состоит из корневого класса `OrioksClient` и ряда категорий, которые предоставляют доступ к информации ресурса. Инстанс клиента инициализируется с помощью объекта `OrioksAccount`, который хранит логин, пароль и возможно пустую строку с токеном доступа к OpenAPI Orioks.

Примеры получения инстанса клиента будут приведены ниже.

## Доступные методы и их описание

Рассмотрим доступные для использования методы по категориям:

### Парс или получение респонсов на доступные запросы `orioks.miet.ru`  и `miet.ru`

- Дисциплины (`DisciplinesCategory`)

  - Метод `GetCurrentDisciplinesInfos()`

    Получить информацию о текущих дисциплинах.

    ```c#
    var disciplines = _client.Disciplines.GetCurrentDisciplinesInfos(); // объект со списком дисциплин
    
    foreach (var item in disciplines.Items) {
        Console.WriteLine(item.Name); // вывод названия предмета
    }
    ```

  - Метод `GetDisciplineInfoById(int semesterId, int studentId)`

    Получить информацию о дисциплинах конкретного семестра и студента.

    ```c#
    var disciplines = _client.Disciplines.GetDisciplineInfoById(29, 1345); // объект со списком дисциплин
    
    foreach (var item in disciplines.Items) {
        Console.WriteLine(item.Name); // вывод названия предмета
    }
    ```

  - Метод `GetResoursesByDiscipline(Discipline discipline)`

    Получить ресурсы дисциплины.

    ```c#
    var resourses = _client.Disciplines.GetResoursesByDiscipline(discipline); // объект ресурсов
    
    foreach (var item in resourses.ResoursesList) {
        Console.WriteLine(item.Name); // вывод названия модуля из ресурсов
    }
    ```

- Новости (`NewsCategory`)

  - Метод `GetNews(bool getDescriptions)`

    Получить все новости с или без подробного описания.

    ```c#
    var news = _client.News.GetNews(false); // получение списка новостей
    
    foreach (var item in news) {
        Console.WriteLine(item.Title); // вывод заголовка новости
    }
    ```

  - Метод `GetNewsItemsDesc(NewsItem item)`

    Получить описание новости.

    ```c#
    var desc = _client.News.GetNewsItemsDesc(item);
    
    Console.WriteLine(item.Description);
    ```

- Расписание (`SheduleNoApiCategory`)

  - Метод `GetDisciplineScheduleItemsAsync(string groupKey)`

    Получить расписание группы по ее ключу.

    ```c#
    var key = "БТС-11";
    var schedule = _client.ScheduleNoApi.GetDisciplineScheduleItemsAsync(key);
    
    Console.WriteLine(schedule.Semestr); // текущий семестр
    ```

- Преподаватели (`TeacherCategory`)

  - Метод `GetTeachersInfo(string name)`

    Получить информацию о преподавателе по его полному имени.

    ```c#
    var teacherInfo = _client.Teacher.GetTeachersInfo(fullName);
    
    Console.WriteLine(teacherInfo.Biography);
    ```

### Официальное OpenAPI

Категории этого раздела `ScheduleCategory`, `StudentCategory` требуют получения токена доступа по следующему запросу:

```http
GET /api/v1/auth HTTP/1.1
Accept: application/json
Authorization: Basic <encoded_auth>
User-Agent: <app>/<app-version> <os>[ <os-version>]
```

`<encoded_auth>`
Разделённые двоеточием `логин:пароль`, закодированные в Base64.

`<app>`

Имя приложения, использующего токен.

`<app-version>`

Версия приложения, использующего токен.

`<os>`

Операционная система, на которой запущено приложение (по возможности с её версией).

Отправить его можно, например, через `Postman`. 

Однако примеры использования методов данных категорий не приводятся, так как использование OpenAPI Orioks не рекомендуется из-за его неудобства (кривые контракты) и ненадежности (токен можно получить лишь восемь раз). 

## Пакеты, использованные в разработке

При разработке методов взаимодействия с OpenAPI использовался пакет [RestSharp](https://restsharp.dev/), который упрощает отправку запросов и обработку репонсов.

Для парсинга сайтов, указанных выше, при разработке оставшейся части библиотеки, активно использовался пакет [AngleSharp](https://anglesharp.github.io/). 

