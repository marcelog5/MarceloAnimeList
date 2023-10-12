namespace MarceloAnimeList.Domain.Entity
{
    public class Anime : Media
    {
        public int EpisodeCount { get; set; }
        public int Season { get; set; }
    }
}
