using CarRare.Common.DomainLayer.Data;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Data.Entity
{
    public class UserAnime : IDomainEntity
    {
        public Guid Id { get; set; }
        public EnUserMediaStatus Status { get; set; }
        public int? Episode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; } = true;
        public Guid AnimeId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
