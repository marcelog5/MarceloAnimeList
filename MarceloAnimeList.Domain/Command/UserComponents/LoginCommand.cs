using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserComponents
{
    public class LoginCommand : ICommandInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
