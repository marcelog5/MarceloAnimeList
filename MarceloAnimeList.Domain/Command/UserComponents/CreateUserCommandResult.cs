using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserComponents
{
    public class CreateUserCommandResult : ICommandResult<CreateUserCommandResponse>
    {
        public bool Success { get; set; }
        public CreateUserCommandResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
