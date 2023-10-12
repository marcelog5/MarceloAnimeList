using CarRare.Commom.DomainLayer.Data;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Entity
{
    public class Rating : IDomainEntity
    {
        public Guid Id { get; set; }
        public EnRatingType Type { get; set; }
        public double? Score { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
    }
}
