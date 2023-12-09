using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserComponents
{
    public class CreateUserCommand : ICommandInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
