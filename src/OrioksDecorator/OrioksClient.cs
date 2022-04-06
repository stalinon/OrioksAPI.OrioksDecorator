using OrioksDecorator.Categories.Impl;
using OrioksDecorator.Categories.Interfaces;
using OrioksDecorator.Utility;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace OrioksDecorator
{
    /// <summary>
    ///     Корневой класс библиотеки,
    ///     реализующий категории работы
    ///     с системой
    /// </summary>
    public sealed class OrioksClient
    {
        private static HttpClient _client;
        private static RestClient _clientRest;

        private static bool _isAuthorized = true;
        private static bool _hasToken;

        /// <summary>
        ///     Создание объекта <see cref="OrioksClient"/>
        /// </summary>
        public static async Task<OrioksClient> Instance(OrioksAccount account)
        {
            var instance = new OrioksClient(account);
            await instance.Auth(account);

            instance.News = new NewsCategory(_client);
            instance.Disciplines = new DisciplinesCategory(_client);
            instance.Teacher = new TeacherCategory(_client);
            instance.ScheduleNoApi = new ScheduleNoAPICategory(_client);

            if (account.Token != null && account.Token != string.Empty)
            {
                _hasToken = true;
                _clientRest = new RestClient("https://orioks.miet.ru/")
                {
                    Authenticator = new JwtAuthenticator(account.Token),
                };

                _clientRest.AddDefaultHeader("Accept", "application/json");
                _clientRest.AddDefaultHeader("User-Agent", "PostmanRuntime/7.28.4 Windows 10");

                instance.Schedule = new ScheduleCategory(_clientRest);
                instance.Student = new StudentCategory(_clientRest);
            }

            return instance;
        }

        /// <inheritdoc cref="OrioksClient"/>
        private OrioksClient(OrioksAccount account)
        {
            var cookies = new CookieContainer();
            var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            _client = new HttpClient(handler);
        }

        /// <summary>
        ///     Авторизация
        /// </summary>
        private async Task Auth(OrioksAccount account)
        {
            var url = "https://orioks.miet.ru/user/login";

            var response = await _client.GetAsync(url);

            var html = await response.Content.ReadAsStringAsync();

            var input = html.Split('\n').Where(x => x.Contains("input")).FirstOrDefault()!;

            var _csrf = input.Split('"')[5];

            var login = account.Username;

            var password = account.Password;

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"_csrf", _csrf}, {"LoginForm[login]", login}, {"LoginForm[password]", password}
            });

            response = await _client.PostAsync(url, content);

            if ((await response.Content.ReadAsStringAsync()).Contains("<div class=\"alert alert-danger\">"))
            {
                _isAuthorized = false;
            }
        }

        private INewsCategory? _news;
        private IDisciplinesCategory? _disciplines;
        private IStudentCategory? _student;
        private IScheduleCategory? _schedule;

        /// <inheritdoc cref="INewsCategory"/>
        public INewsCategory? News
        {
            get => _isAuthorized ? _news : throw new AuthException("Not authorized"); 
            private set => _news = value;
        }

        /// <inheritdoc cref="IDisciplinesCategory"/>
        public IDisciplinesCategory? Disciplines
        {
            get => _isAuthorized ? _disciplines : throw new AuthException("Not authorized");
            private set => _disciplines = value;
        }

        /// <inheritdoc cref="IStudentCategory"/>
        public IStudentCategory? Student
        {
            get => _hasToken ? _student : throw new AuthException("Got no auth token");
            private set => _student = value;
        }

        /// <inheritdoc cref="IScheduleCategory"/>
        public IScheduleCategory? Schedule
        {
            get => _hasToken ? _schedule : throw new AuthException("Got no auth token");
            private set => _schedule = value;
        }

        /// <inheritdoc cref="ITeacherCategory"/>
        public ITeacherCategory Teacher { get; private set; } = default!;

        /// <inheritdoc cref="IScheduleNoAPICategory"/>
        public IScheduleNoAPICategory ScheduleNoApi { get; set; } = default!;

    }
}
