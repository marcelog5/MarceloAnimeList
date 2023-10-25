using CarRare.Commom.ApplicationLayer.Data;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;

namespace MarceloAnimeList.Infra._4._1_Data.Repository
{
    public class UserAnimeRepository : EntityFrameworkRepository<UserAnime, Guid>, IUserAnimeRepository
    {
        public UserAnimeRepository(DataContext dbContext) : base(dbContext) { }
    }
}
