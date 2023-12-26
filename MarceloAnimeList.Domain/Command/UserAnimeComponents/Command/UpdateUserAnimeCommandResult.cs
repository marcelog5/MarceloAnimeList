using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Command
{
    public class UpdateUserAnimeCommandResult : ICommandResult<UpdateUserAnimeCommandResponse>
    {
        public bool Success { get; set; }
        public UpdateUserAnimeCommandResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
