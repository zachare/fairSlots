using fairSlots.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fairSlots.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GameHistoryController : ControllerBase
    {

        private readonly ILogger<GameHistoryController> _logger;

        public GameHistoryController(ILogger<GameHistoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GameHistory> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new GameHistory
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                GameNumber = Random.Shared.Next(0, 55),
                Funds = Random.Shared.Next(0, 1000),
                BetAmount = Random.Shared.Next(0, 50)
            })
            .ToArray();
        }
    }
}