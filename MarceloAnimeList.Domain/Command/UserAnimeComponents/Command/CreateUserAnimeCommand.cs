using CarRare.Commom.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Command
{
    public class CreateUserAnimeCommand : ICommandInput
    {
        public string AnimeName { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
    }
}
