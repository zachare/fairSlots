using fairSlots.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fairSlots.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _context;

        public GameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return Ok(games);
        }

        [HttpGet("player")]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(int id)
        {
            var game = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (game == null)
            {
                return NotFound("Sorry, there is no games here. :/");
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<List<Game>>> CreateGame(Game game)
        {
            game.Player = null;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Game>>> UpdateGame(Game game, int id)
        {
            var dbGame = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (dbGame == null)
                return NotFound("Sorry, this game does not exist.");

            dbGame.PlayerID = game.PlayerID;
            dbGame.Date = game.Date;
            dbGame.Funds = game.Funds;
            dbGame.BetAmount = game.BetAmount;
            dbGame.Win = game.Win;

            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> DeleteGame(int id)
        {
            var dbGame = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (dbGame == null)
                return NotFound("Sorry, this game does not exist.");

            _context.Games.Remove(dbGame);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        private async Task<List<Game>> GetDbGames()
        {
            return await _context.Games.Include(g => g.Player).ToListAsync();
        }
    }
}
