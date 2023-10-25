using MarceloAnimeList.Domain.Data.Model;
using System.Net.Http.Json;

namespace MarceloAnimeList.Service.Service.HttpService
{
    public class MALHttpClient
    {
        private HttpClient _httpClient;

        public MALHttpClient
        (
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<MyAnimeListModel> GetAnime(string AnimeName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"v4/anime?q={AnimeName}&&limit=1");
            return await response.Content.ReadFromJsonAsync<MyAnimeListModel>();
        }
    }
}
