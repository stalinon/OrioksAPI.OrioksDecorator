using OrioksDecorator.Categories.Impl;
using OrioksDecorator.Categories.Interfaces;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace OrioksDecorator
{
    public class OrioksClient
    {
        private static HttpClient _client;
        private static RestClient _clientRest;

        public static async Task<OrioksClient> Instance(OrioksAccount account)
        {
            var instance = new OrioksClient(account);
            await instance.Auth(account);

            instance.News = new NewsCategory(_client);
            instance.Disciplines = new DisciplinesCategory(_client);

            if (account.Token != null && account.Token != string.Empty)
            {

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

        private OrioksClient(OrioksAccount account)
        {
            var cookies = new CookieContainer();
            var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            _client = new HttpClient(handler);
        }

        private async Task Auth(OrioksAccount account)
        {
            var url = "https://orioks.miet.ru/user/login";

            var response = await _client.GetAsync(url);

            var html = await response.Content.ReadAsStringAsync();

            var input = html.Split('\n').Where(x => x.Contains("input")).FirstOrDefault();

            var _csrf = input.Split('"')[5];

            var login = account.Username;

            var password = account.Password;

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"_csrf", _csrf}, {"LoginForm[login]", login}, {"LoginForm[password]", password}
            });

            await _client.PostAsync(url, content);
        }

        public INewsCategory News { get; private set; }
        public IDisciplinesCategory Disciplines { get; private set; }
        public IStudentCategory Student { get; private set; }
        public IScheduleCategory Schedule { get; private set; }

    }
}
