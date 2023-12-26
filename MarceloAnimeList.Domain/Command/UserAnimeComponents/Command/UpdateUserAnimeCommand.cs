using CarRare.Common.DomainLayer.Command;

namespace MarceloAnimeList.Domain.Command.UserAnimeComponents.Command
{
    public class UpdateUserAnimeCommand : ICommandInput
    {
        public Guid Id { get; set; }
        //public JsonPatchDocument<UpdateUserAnimeConfiguration> Configuration { get; set; }
    }
}
