namespace fairSlots.Shared.Models
{
    public class GameHistory
    {
        public DateOnly Date { get; set; }
        public int GameNumber { get; set; }
        public decimal Funds { get; set; }
        public decimal BetAmount { get; set; }
    }
}