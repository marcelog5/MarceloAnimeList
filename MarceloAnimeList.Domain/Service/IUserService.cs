using MarceloAnimeList.Domain.Command.UserComponents;

namespace MarceloAnimeList.Domain.Service
{
    public interface IUserService
    {
        Task<CreateUserCommandResult> Create(CreateUserCommand command);
    }
}
