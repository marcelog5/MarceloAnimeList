using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;

namespace MarceloAnimeList.Domain.Service
{
    public interface IUserAnimeService
    {
        Task<CreateUserAnimeCommandResult> Create(CreateUserAnimeCommand command);
        Task<GetUserAnimeQueryResult> Get(GetUserAnimeQuery query);
    }
}
