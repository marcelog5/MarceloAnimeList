using CarRare.Common.DomainLayer.Data;

namespace MarceloAnimeList.Domain.Data.Entity
{
    public class User : IDomainEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<UserAnime>? UserAnimes { get; set; }
    }
}
