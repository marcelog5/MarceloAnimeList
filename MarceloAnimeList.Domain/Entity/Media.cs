using CarRare.Commom.DomainLayer.Data;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Entity
{
    public class Media : IDomainEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public EnMediaGenreType Genre { get; set; }
        public EnMediaStatus Status { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
    }
}
