using OrioksDecorator.Categories.Impl;
using OrioksDecorator.Categories.Interfaces;
using System.Net;

namespace OrioksDecorator
{
    public class OrioksDecorator
    {
        private static HttpClient _client;

        public static async Task<OrioksDecorator> Instance(OrioksAccount account)
        {
            var instance = new OrioksDecorator(account);
            await instance.Auth(account);

            instance.News = new NewsCategory(_client);
            instance.Student = new StudentCategory(_client);
            
            return instance;
        }

        private OrioksDecorator(OrioksAccount account)
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
        public IStudentCategory Student { get; private set; }

    }
}
