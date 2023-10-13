using CarRare.Commom.ApplicationLayer.Data;
using MarceloAnimeList.Domain.Data.Entity;
using MarceloAnimeList.Domain.Data.Repository;

namespace MarceloAnimeList.Infra._4._1_Data.Repository
{
    public class UserRepository : EntityFrameworkRepository<User, Guid>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext) { }
    }
}
