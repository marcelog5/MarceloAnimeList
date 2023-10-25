using MarceloAnimeList.Domain.Command.UserAnimeComponents.Query;
using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarceloAnimeList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimeController : ControllerBase
    {
        private IMediator _mediator;

        public UserAnimeController
        (
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        // GET: api/<UserAnimeController>
        [HttpGet]
        public async Task<GetUserAnimeQueryResult> Get
        (
            [FromRoute] GetUserAnimeRequest request
        )
        {
            return await _mediator.Send(request);
        }

        // POST api/<UserAnimeController>
        [HttpPost]
        public async Task Post([FromBody] CreateUserAnimeRequest request)
        {
            await _mediator.Send(request);
        }
    }
}
