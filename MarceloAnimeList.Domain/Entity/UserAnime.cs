using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Entity
{
    public class UserAnime
    {
        public EnUserMediaStatus Status { get; set; }
        public int? Episode { get; set; }
        public int Season { get; set; }
        public Rating? Rate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
