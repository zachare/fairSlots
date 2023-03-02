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
        public class ChanceController : ControllerBase
        {
            private readonly DataContext _context;
            public ChanceController(DataContext context)
            {
                _context = context;
            }
            [HttpGet]
            public async Task<ActionResult<List<Chance>>> GetChances()
            {
                var chances = await _context.Chances.ToListAsync();
                return Ok(chances);
            }

            [HttpGet("player")]
            public async Task<ActionResult<List<Player>>> GetPlayers()
            {
                var players = await _context.Players.ToListAsync();
                return Ok(players);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Chance>> GetSingleChance(int id)
            {
                var chance = await _context.Chances
                    .FirstOrDefaultAsync(c => c.ChanceID == id);
                if (chance == null)
                {
                    return NotFound("Sorry, this chance does not exist.");
                }
                return Ok(chance);
            }

            [HttpPost]
            public async Task<ActionResult<List<Chance>>> CreateChance(Chance chance)
            {
                chance.Player = null;
                _context.Chances.Add(chance);
                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }
            [HttpPut("{id}")]
            public async Task<ActionResult<List<Chance>>> UpdateChance(Chance chance, int id)
            {
                var dbChance = await _context.Chances
                    .Include(c => c.Player)
                    .FirstOrDefaultAsync(c => c.ChanceID == id);
                if (dbChance == null)
                    return NotFound("Sorry, this chance does not exist.");

                dbChance.PlayerID = chance.PlayerID;
                dbChance.WinRate = chance.WinRate;
                dbChance.UpdateTime = chance.UpdateTime;

                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Chance>>> DeleteChance(int id)
            {
                var dbChance = await _context.Chances
                    .Include(c => c.Player)
                    .FirstOrDefaultAsync(c => c.ChanceID == id);
                if (dbChance == null)
                    return NotFound("Sorry, this chance does not exist.");

                _context.Chances.Remove(dbChance);
                await _context.SaveChangesAsync();

                return Ok(await GetDbChances());
            }

            private async Task<List<Chance>> GetDbChances()
            {
                return await _context.Chances.Include(c => c.Player).ToListAsync();
            }
        }
    }

}
