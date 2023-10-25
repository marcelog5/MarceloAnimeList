using MarceloAnimeList.Domain.Command.UserComponents;

namespace MarceloAnimeList.Domain.Service
{
    public interface IUserService
    {
        Task<LoginCommandResult> Login(LoginCommand command);
        Task<CreateUserCommandResult> Create(CreateUserCommand command);
    }
}
