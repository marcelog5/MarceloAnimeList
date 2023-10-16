using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Data.Entity
{
    public class Anime : Media
    {
        public EnAnimeType Type { get; set; }
        public int? EpisodeCount { get; set; }
        public int? Season { get; set; }
    }
}
