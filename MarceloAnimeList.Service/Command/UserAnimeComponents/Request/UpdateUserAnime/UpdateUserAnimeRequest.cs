using MarceloAnimeList.Domain.Command.UserAnimeComponents.Command;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Request.UpdateUserAnime
{
    public class UpdateUserAnimeRequest : IRequest<UpdateUserAnimeCommandResult>
    {
        public Guid Id { get; set; }
        [FromBody]
        public JsonPatchDocument<UpdateUserAnimeConfiguration> Configuration { get; set; }
    }
}
