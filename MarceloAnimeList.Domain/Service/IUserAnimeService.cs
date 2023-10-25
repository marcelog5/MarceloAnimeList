using MarceloAnimeList.Domain.Command.UserAnimeComponents;

namespace MarceloAnimeList.Domain.Service
{
    public interface IUserAnimeService
    {
        Task<GetUserAnimeQueryResult> Get(GetUserAnimeQuery query);
    }
}
