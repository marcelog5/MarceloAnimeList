using CarRare.Commom.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserComponents
{
    public class CreateUserCommand : ICommandInput
    {
        public string Name { get; set; }
    }
}
