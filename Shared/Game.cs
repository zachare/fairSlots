using System.ComponentModel.DataAnnotations;

namespace fairSlots.Shared
{
    public class Game
    {
        [Required]
        public int GameID { get; set; }
        [Required]
        public int PlayerID { get; set; }
        public Player? Player { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal BetAmount { get; set; }
        [Required]
        public bool Win { get; set; }

    }
}