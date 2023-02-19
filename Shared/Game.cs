using System.ComponentModel.DataAnnotations;

namespace fairSlots.Shared
{
    public class Game
    {
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public Player? Player { get; set; }
        public DateTime Date { get; set; }
        public decimal Funds { get; set; }
        public decimal BetAmount { get; set; }
        public bool Win { get; set; }

    }
}