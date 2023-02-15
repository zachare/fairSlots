using System.ComponentModel.DataAnnotations;

namespace fairSlots.Shared
{
    public class Game
    {
        public int GameID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public decimal Funds { get; set; }
        public decimal BetAmount { get; set; }
        public bool Win { get; set; }

        public Game()
        {

        }

        public Game(int GameID, int UserID, DateTime Date, decimal Funds, decimal BetAmount, bool Win)
        {
            this.GameID = GameID;
            this.UserID = UserID;
            this.Date = Date;
            this.Funds = Funds;
            this.BetAmount = BetAmount;
            this.Win = Win;
        }

    }
}