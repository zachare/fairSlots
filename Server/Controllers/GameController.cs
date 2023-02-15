using fairSlots.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fairSlots.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private List<Game> Games = new()
        {
            new(1, 1, DateTime.Now, 100.00m, 25.00m, true),
            new(2, 1, DateTime.Now, 125.00m, 25.00m, false),
            new(3, 1, DateTime.Now, 100.00m, 50.00m, false),
            new(4, 1, DateTime.Now, 50.00m, 25.00m, true),


        };

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var game = Games.Find(o => o.GameID == id);

            if (game is not null)
            {
                return Ok(game);
            }
            return NotFound("This Game was not found");
        }

        [HttpGet("List")]
        public ActionResult List()
        {
            return Ok(Games);
        }
    }
}
