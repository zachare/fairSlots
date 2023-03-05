using fairSlots.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// Handles Server-Side Chance API calls
namespace fairSlots.Server.Controllers
{

    namespace fairSlots.Server.Controllers
    {
        // Only Admin and Manager roles can call these methods/access their corresponding pages
        // Uses api/chance
        [Authorize(Roles = "Admin, Manager")]
        [Route("api/[controller]")]
        [ApiController]
        public class ChanceController : ControllerBase
        {
            private readonly DataContext _context;
            public ChanceController(DataContext context)
            {
                _context = context;
            }

            // Gets a list of Chances
            [HttpGet]
            public async Task<ActionResult<List<Chance>>> GetChances()
            {
                var chances = await _context.Chances.ToListAsync();
                return Ok(chances);
            }

            // Gets a list of Players via Chances
            [HttpGet("player")]
            public async Task<ActionResult<List<Player>>> GetPlayers()
            {
                var players = await _context.Players.ToListAsync();
                return Ok(players);
            }

            // Gets a single Chance object via it's ID (PlayerID)
            [HttpGet("{id}")]
            public async Task<ActionResult<Chance>> GetSingleChance(int id)
            {
                // Selects the Chance with the given ID
                var chance = await _context.Chances
                    .FirstOrDefaultAsync(c => c.PlayerID == id);
                if (chance == null)
                {
                    return NotFound("Sorry, this chance does not exist.");
                }
                return Ok(chance);
            }

            // Creates a new Chance and saves it to the database
            [HttpPost]
            public async Task<ActionResult<List<Chance>>> CreateChance(Chance chance)
            {
                chance.Player = null;
                _context.Chances.Add(chance);
                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }

            // Updates an existing Chance object with a given ID
            [HttpPut("{id}")]
            public async Task<ActionResult<List<Chance>>> UpdateChance(Chance chance, int id)
            {
                // Selects the Chance using the passed in ID
                var dbChance = await _context.Chances
                    .Include(c => c.Player)
                    .FirstOrDefaultAsync(c => c.PlayerID == id);
                if (dbChance == null)
                    return NotFound("Sorry, this chance does not exist.");

                // Updates the Chance object's properties and saves it to the database
                dbChance.WinRate = chance.WinRate;
                dbChance.UpdateTime = chance.UpdateTime;

                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }

            // Deletes a Chance with a given ID
            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Chance>>> DeleteChance(int id)
            {
                // Selects the Chance based on the given ID
                var dbChance = await _context.Chances
                    .Include(c => c.Player)
                    .FirstOrDefaultAsync(c => c.PlayerID == id);
                if (dbChance == null)
                    return NotFound("Sorry, this chance does not exist.");

                // Deletes the selected chance from the local DataContext and saves it to the database
                _context.Chances.Remove(dbChance);
                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }

            // Gets a list of Chances from the database
            private async Task<List<Chance>> GetDbChances()
            {
                return await _context.Chances.Include(c => c.Player).ToListAsync();
            }
        }
    }

}
