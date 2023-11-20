using CarRare.Commom.DomainLayer.Command;
using MarceloAnimeList.Domain.Enum;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Command
{
    public class CreateUserAnimeCommand : ICommandInput
    {
        public string AnimeName { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public EnUserMediaStatus UserAnimeStatus { get; set; }
    }
}
