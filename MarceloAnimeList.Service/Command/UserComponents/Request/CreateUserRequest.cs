using MarceloAnimeList.Domain.Command.UserComponents;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Request
{
    public class CreateUserRequest : IRequest<CreateUserCommandResult>
    {
        public string Name { get; set; }
    }
}
