using MarceloAnimeList.Service.Command.UserComponents.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarceloAnimeList.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController
        (
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        // POST api/<UserController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
