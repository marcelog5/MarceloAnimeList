using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarceloAnimeList.Service.Command.UserAnimeComponents.Request.UpdateUserAnime
{
    public class UpdateUserAnimeRequest : IRequest<object>
    {
        public Guid Id { get; set; }
        [FromBody]
        public JsonPatchDocument<UpdateUserAnimeConfiguration> Configuration { get; set; }
    }
}
