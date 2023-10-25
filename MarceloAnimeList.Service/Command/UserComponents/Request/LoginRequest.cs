using MarceloAnimeList.Domain.Command.UserComponents;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Request
{
    public class LoginRequest : IRequest<LoginCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
