namespace fairSlots.Shared.Models
{
    public class GameHistory
    {
        public int GameID { get; set; }
        public int UserID { get; set; }
        public DateOnly Date { get; set; }
        public decimal Funds { get; set; }
        public decimal BetAmount { get; set; }
    }
}