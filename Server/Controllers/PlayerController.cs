using fairSlots.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// Handles Server-Side Player API calls 
namespace fairSlots.Server.Controllers
{

    namespace fairSlots.Server.Controllers
    {
        // Uses api/player for storage
        [Route("api/[controller]")]
        [ApiController]
        public class PlayerController : ControllerBase
        {
            private readonly DataContext _context;
            public PlayerController(DataContext context)
            {
                _context = context;
            }
            // Gets a list of players from the DataContext
            [HttpGet]
            public async Task<ActionResult<List<Player>>> GetPlayers()
            {
                var players = await _context.Players.ToListAsync();
                return Ok(players);
            }

            // Retrieves the information of one Player using the ID as the route
            [HttpGet("{id}")]
            public async Task<ActionResult<Player>> GetSinglePlayer(int id)
            {
                // Selects first player with a matching ID or returns error
                var player = await _context.Players
                    .FirstOrDefaultAsync(h => h.PlayerID == id);
                if (player == null)
                {
                    return NotFound("Sorry, this player does not exist.");
                }
                return Ok(player);
            }

            // Creates a Player (parameter) in the local DataContext field and then saves it to the database
            [HttpPost]
            public async Task<ActionResult<List<Player>>> CreatePlayer(Player player)
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }

            // Updates a Players information by selecting the given player via ID
            [HttpPut("{id}")]
            public async Task<ActionResult<List<Player>>> UpdatePlayer(Player player, int id)
            {
                var dbPlayer = await _context.Players
                    .FirstOrDefaultAsync(sd => sd.PlayerID == id);
                if (dbPlayer == null)
                    return NotFound("Sorry, this player does not exist.");

                // Sets the passed in Player object's properties to the locally created one
                dbPlayer.PlayerID = player.PlayerID;
                dbPlayer.Username = player.Username;
                dbPlayer.Funds = player.Funds;

                // Saves the updated Player to the database
                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }

            // Deletes a given Player via its ID
            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Player>>> DeletePlayer(int id)
            {
                // Selects Player with the id
                var dbPlayer = await _context.Players
                    .FirstOrDefaultAsync(sd => sd.PlayerID == id);
                if (dbPlayer == null)
                    return NotFound("Sorry, this player does not exist.");

                // Removes Player from local DbSet and saves the DbSet to the database
                _context.Players.Remove(dbPlayer);
                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }

            // Gets a list of all Players
            private async Task<List<Player>> GetDbPlayers()
            {
                return await _context.Players.ToListAsync();
            }
        }
    }

}
