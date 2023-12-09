using CarRare.Common.ApplicationLayer.Data;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;

namespace MarceloAnimeList.Infra._4._1_Data.Repository
{
    public class AnimeRepository : EntityFrameworkRepository<Anime, Guid>, IAnimeRepository
    {
        public AnimeRepository(DataContext dbContext) : base(dbContext) { }
    }
}
