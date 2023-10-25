using System.Net.Http.Headers;

namespace MarceloAnimeList.Service.Service.HttpService
{
    public class MALHttpClientFactory : IHttpClientFactory
    {
        private string url = "https://api.jikan.moe";
        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
