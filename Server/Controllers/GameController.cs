using fairSlots.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Handles Server-Side Game API calls 
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

        // Retrieves a list of Games
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _context.Games.ToListAsync();
            return Ok(games);
        }

        // Retrieves a list of Players (used for Player selection on Games)
        [HttpGet("player")]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        // Returns a single Game object with the given ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetSingleGame(int id)
        {
            // Selects Game with the ID and includes its Player object
            var game = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (game == null)
            {
                return NotFound("Sorry, there is no game here.");
            }
            return Ok(game);
        }

        // Creates a new Game object
        [HttpPost]
        public async Task<ActionResult<List<Game>>> CreateGame(Game game)
        {
            // Sets the Game's Player object as null initially
            game.Player = null;
            // Adds Game to the database and saves it
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        // Updates an existing Game object using it's ID
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Game>>> UpdateGame(Game game, int id)
        {
            // Selects the Game with its ID, including it's Player object
            var dbGame = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (dbGame == null)
                return NotFound("Sorry, this game does not exist.");

            // Resets the Game objects properties to the updated ones and saves it to the database
            dbGame.PlayerID = game.PlayerID;
            dbGame.Date = game.Date;
            dbGame.BetAmount = game.BetAmount;
            dbGame.Win = game.Win;

            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        // Deletes a game using it's ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> DeleteGame(int id)
        {
            // Selects the Game using it's ID and includes it's Player object
            var dbGame = await _context.Games
                .Include(g => g.Player)
                .FirstOrDefaultAsync(g => g.GameID == id);
            if (dbGame == null)
                return NotFound("Sorry, this game does not exist.");

            // Removes the Game from the local DataContext and saves it to the database
            _context.Games.Remove(dbGame);
            await _context.SaveChangesAsync();

            return Ok(await GetDbGames());
        }

        // Returns a list of all Games in the database
        private async Task<List<Game>> GetDbGames()
        {
            return await _context.Games.Include(g => g.Player).ToListAsync();
        }
    }
}
