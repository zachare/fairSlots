
namespace fairSlots.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
            new Player { PlayerID = 1, Username = "Zach", Funds = 200.00m, WinRate = 0.50m },
            new Player { PlayerID = 2, Username = "Admin", Funds = 5000.00m, WinRate = 0.99m }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameID = 1,
                    PlayerID = 1,
                    Date = DateTime.Now,
                    BetAmount = 20.00m,
                    Win = true
                },

            new Game
            {
                GameID = 2,
                PlayerID = 2,
                Date = DateTime.Now,
                BetAmount = 50.00m,
                Win = false
            }
            );
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }
    }

}

