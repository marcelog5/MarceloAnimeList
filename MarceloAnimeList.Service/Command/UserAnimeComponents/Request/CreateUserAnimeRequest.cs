using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MarceloAnimeList.Domain.Enum;
using MediatR;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Request
{
    public class CreateUserAnimeRequest : IRequest<CreateUserAnimeCommandResult>
    {
        public string AnimeName { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public EnUserMediaStatus UserAnimeStatus { get; set; }
    }
}
