using MarceloAnimeList.Service.Command.UserAnimeComponents.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarceloAnimeList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimeController : ControllerBase
    {
        // GET: api/<UserAnimeController>
        [HttpGet]
        public IEnumerable<string> Get
        (
            [FromRoute] GetUserAnimeRequest request
        )
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserAnimeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserAnimeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserAnimeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAnimeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
