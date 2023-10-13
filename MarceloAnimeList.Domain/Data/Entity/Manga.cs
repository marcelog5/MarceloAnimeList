namespace MarceloAnimeList.Domain.Data.Entity
{
    public class Manga : Media
    {
        public int Chapter { get; set; }
        public int Pages { get; set; }
    }
}
