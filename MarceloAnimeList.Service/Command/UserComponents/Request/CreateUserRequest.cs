using MediatR;

namespace MarceloAnimeList.Service.Command.UserComponents.Request
{
    public class CreateUserRequest : IRequest<object>
    {
        public string Name { get; set; }
    }
}
