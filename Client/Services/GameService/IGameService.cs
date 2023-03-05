namespace fairSlots.Client.Services.GameService
{
    // Initializes the IGameService interface to be inherited by GameService
    public interface IGameService
    {
        List<Game> Games { get; set; }
        List<Player> Players { get; set; }
        Task GetPlayers();
        Task GetGames();
        Task<Game> GetSingleGame(int id);
        Task CreateGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(int id);
    }
}
