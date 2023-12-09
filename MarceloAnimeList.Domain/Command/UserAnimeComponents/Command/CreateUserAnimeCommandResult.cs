using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Command
{
    public class CreateUserAnimeCommandResult : ICommandResult<CreateUserAnimeCommandResponse>
    {
        public bool Success { get; set; }
        public CreateUserAnimeCommandResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
