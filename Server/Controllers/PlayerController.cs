using fairSlots.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace fairSlots.Server.Controllers
{

    namespace fairSlots.Server.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PlayerController : ControllerBase
        {
            private readonly DataContext _context;
            public PlayerController(DataContext context)
            {
                _context = context;
            }
            [HttpGet]
            public async Task<ActionResult<List<Player>>> GetPlayers()
            {
                var players = await _context.Players.ToListAsync();
                return Ok(players);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Player>> GetSinglePlayer(int id)
            {
                var player = await _context.Players
                    .FirstOrDefaultAsync(h => h.PlayerID == id);
                if (player == null)
                {
                    return NotFound("Sorry, this player does not exist.");
                }
                return Ok(player);
            }

            [HttpPost]
            public async Task<ActionResult<List<Player>>> CreatePlayer(Player player)
            {
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }
            [HttpPut("{id}")]
            public async Task<ActionResult<List<Player>>> UpdatePlayer(Player player, int id)
            {
                var dbPlayer = await _context.Players
                    .FirstOrDefaultAsync(sd => sd.PlayerID == id);
                if (dbPlayer == null)
                    return NotFound("Sorry, this player does not exist.");

                dbPlayer.PlayerID = player.PlayerID;
                dbPlayer.Username = player.Username;
                dbPlayer.Funds = player.Funds;
                dbPlayer.WinRate = player.WinRate;

                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Player>>> DeletePlayer(int id)
            {
                var dbPlayer = await _context.Players
                    .FirstOrDefaultAsync(sd => sd.PlayerID == id);
                if (dbPlayer == null)
                    return NotFound("Sorry, this player does not exist.");

                _context.Players.Remove(dbPlayer);
                await _context.SaveChangesAsync();

                return Ok(await GetDbPlayers());
            }

            private async Task<List<Player>> GetDbPlayers()
            {
                return await _context.Players.ToListAsync();
            }
        }
    }

}
