using CarRare.Commom.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserComponents
{
    public class LoginCommandResult : ICommandResult<LoginCommandResponse>
    {
        public bool Success { get; set; }
        public LoginCommandResponse? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<Exception>? exceptions { get; set; }
    }
}
