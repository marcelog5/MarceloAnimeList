using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Entity
{
    public class UserMedia
    {
        public EnUserMediaStatus Status { get; set; }
        public int MediaEpisode { get; set; }
        public int MediaSequence { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
